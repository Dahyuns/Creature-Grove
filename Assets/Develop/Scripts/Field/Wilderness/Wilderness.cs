using UnityEngine;

namespace CreatureGrove
{
    public enum CharacterType
    {
        Townsfolk,  // �ֹ�(����ƮX����)
        Enemy      // ����
    }

    enum NatureObjType
    {
        Grass, Tree, Rock
    }

    // �ʵ� - �߻�
    // ����, ���� ���� �� ����
    public class Wilderness : MonoBehaviour
    {
        #region �̱���
        private static Wilderness instance;
        public static Wilderness Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }
            DestroyImmediate(gameObject);
        }
        #endregion

        // ���� (������Ʈ ���� ��ȯ���ִ� �Լ� �߰��ϱ�)
        [SerializeField] private GameObject[] grasses;
        [SerializeField] private GameObject[] trees;
        [SerializeField] private GameObject[] rocks;
        [SerializeField] private GameObject parent;

        // ��ĭ�� ������ ����
        private int totalUnits = 10;
        [SerializeField] private float grassScale = 1;
        [SerializeField] private float treeScale = 1;
        [SerializeField] private float rockScale = 1;

        // sin�Լ� �׷��� ��(�ֱ�) ���� (Ŀ������ ��������, �⺻�� 1)
        [SerializeField] private float Mult = 1;

        private GameObject sineObj;

        private void Start()
        {
            SetNature();
        }

        public void SetNature()
        {
            int[,] array = GridManager.Instance.gridArray;

            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    // �ش� ĭ�� �߻��̶��
                    if (array[x, y] == 0)
                    {
                        InstantiateSineWaveObject(GridManager.Instance.cellSize, NatureObjType.Grass, grassScale, x, y, 0);
                        InstantiateSineWaveObject(GridManager.Instance.cellSize, NatureObjType.Tree,  treeScale, x, y, 2);
                        InstantiateSineWaveObject(GridManager.Instance.cellSize, NatureObjType.Rock,  rockScale, x, y, 4);
                    }
                }
            }
        }

        // ���� �׷����� Ȱ���Ͽ� ������Ʈ�� ���� (��ĭ�� ũ��, ������ ������Ʈ, xĭ ��ȣ, yĭ ��ȣ, ���� �õ尪 (2���� ������))
        private void InstantiateSineWaveObject(float cellSize, NatureObjType ntype, float scale, int x, int y, int seed)
        {
            // ������ �Ʒ� x = sin(y)
            // �� ������ �Ÿ�
            float unit = cellSize / (totalUnits * scale);

            for (int i = 0; i < (totalUnits * scale); i++)
            {
                float numX = (unit * i) + (unit / 2);

                // ����, ������ '����'(=cellSize�� ��) * SIN�Լ� (��� ���� * x��)     + �����̵���(=cellSize�� ��)
                float numY = (cellSize / 2) * Mathf.Sin(Mult * numX + seed) - cellSize / 2;

                switch (ntype)
                {
                    case NatureObjType.Grass:
                        sineObj = Instantiate(RandomGrassObj(), parent.transform);
                        break;

                    case NatureObjType.Tree:
                        sineObj = Instantiate(RandomTreeObj(), parent.transform);
                        break;

                    case NatureObjType.Rock:
                        sineObj = Instantiate(RandomRockObj(), parent.transform);
                        break;
                }

                float newGrassX = this.transform.position.x + x * cellSize + numX;
                float newGrassY = this.transform.position.y + y * cellSize + numY;

                // ���� ��ġ + numX, 0, ������ġ + numZ
                sineObj.transform.position = new Vector3(newGrassX, 0, newGrassY);
            }
        }

        #region �ν����� â �� �迭���� ������ ������Ʈ ��ȯ
        private GameObject RandomGrassObj()
        {
            int i = Random.Range(0, grasses.Length);

            return grasses[i];
        }

        private GameObject RandomTreeObj()
        {
            int i = Random.Range(0, trees.Length);

            return trees[i];
        }

        private GameObject RandomRockObj()
        {
            int i = Random.Range(0, rocks.Length);

            return rocks[i];
        }
        #endregion
    }
}
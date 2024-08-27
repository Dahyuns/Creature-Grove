using UnityEngine;

namespace CreatureGrove
{
    public enum CharacterType
    {
        Townsfolk,  // �ֹ�(����ƮX����)
        Enemy      // ����
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
        [SerializeField] private GameObject[] mushrooms;
        [SerializeField] private GameObject parent;

        // ��ĭ�� ������ ����
        private int totalUnits = 10;
        [SerializeField] private float grassScale = 1;
        [SerializeField] private float treeScale = 1;
        [SerializeField] private float rockScale = 1;
        [SerializeField] private float mushroomScale = 1;

        // sin�Լ� �׷��� ��(�ֱ�) ���� (Ŀ������ ��������, �⺻�� 1)
        [SerializeField] private float Mult = 1;

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
                        InstantiateSineWaveObject(GridManager.Instance.cellSize, mushrooms, mushroomScale, x, y, 0);
                        InstantiateSineWaveObject(GridManager.Instance.cellSize, grasses, grassScale, x, y, 2);
                        InstantiateSineWaveObject(GridManager.Instance.cellSize, trees,  treeScale, x, y, 3);
                        InstantiateSineWaveObject(GridManager.Instance.cellSize, rocks,  rockScale, x, y, 4);
                    }
                }
            }
        }

        // ���� �׷����� Ȱ���Ͽ� ������Ʈ�� ���� (��ĭ�� ũ��, ������ ������Ʈ, xĭ ��ȣ, yĭ ��ȣ, ���� �õ尪 (2���� ������))
        private void InstantiateSineWaveObject(float cellSize, GameObject[] array, float scale, int x, int y, int seed)
        {
            // ������ �Ʒ� x = sin(y)
            // �� ������ �Ÿ�
            float unit = cellSize / (totalUnits * scale);

            for (int i = 0; i < (totalUnits * scale); i++)
            {
                float numX = (unit * i) + (unit / 2);

                // ����, ������ '����'(=cellSize�� ��) * SIN�Լ� (��� ���� * x��)     + �����̵���(=cellSize�� ��)
                float numY = (cellSize / 2) * Mathf.Sin(Mult * numX + seed) - cellSize / 2;

                GameObject sineObj = Instantiate(RandomObj(array), parent.transform);

                float newGrassX = this.transform.position.x + x * cellSize + numX;
                float newGrassY = this.transform.position.y + y * cellSize + numY;

                // ���� ��ġ + numX, 0, ������ġ + numZ
                sineObj.transform.position = new Vector3(newGrassX, 0, newGrassY);
            }
        }

        // �ν����� â �� �迭���� ������ ������Ʈ ��ȯ
        private GameObject RandomObj(GameObject[] array)
        {
            int i = Random.Range(0, array.Length);

            return array[i];
        }
    }
}
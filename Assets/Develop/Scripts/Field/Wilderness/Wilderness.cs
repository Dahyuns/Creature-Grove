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

        private void Start()
        {
            SetNature();
        }

        // [�� �ε��, ���ʵ� ����] (����, ������� �����ϱ�)
        // ����
        [SerializeField] private GameObject grass;
        [SerializeField] private GameObject tree;
        [SerializeField] private GameObject rock;

        // ��ĭ�� ������ ����
        private int totalUnits = 10;

        // sin�Լ� �׷��� �� ���� (Ŀ������ ��������, �⺻�� 1)
        public float cycleMulti = 1;


        public void SetNature()
        {
            int[,] array = GridManager.Instance.gridArray;

            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    // �ش� ĭ�� �߻��̶��
                    if (array[x,y] == 0)
                    {
                        InstantiateSineWaveObject(GridManager.Instance.cellSize, grass, x, y,0);
                        InstantiateSineWaveObject(GridManager.Instance.cellSize, tree, x, y, 2);
                        InstantiateSineWaveObject(GridManager.Instance.cellSize, rock, x, y, 4);
                    }
                }
            }
        }

        public void InstantiateSineWaveObject(float cellSize, GameObject obj, int x, int y, int seed)
        {
            Debug.Log("InstantiateSineWaveObject On");
            // ������ �Ʒ� x = sin(y)
            // �� ������ �Ÿ�
            float unit = cellSize / totalUnits;

            for (int  i = 0; i < totalUnits; i++)
            {
                float numX = (unit * i) + (unit / 2); 

                // ����, ������ '����'(=cellSize�� ��) * SIN�Լ� (��� ���� * x��)     + �����̵���(=cellSize�� ��)
                float numY = (cellSize / 2)          * Mathf.Sin(cycleMulti * numX + seed) - cellSize / 2; // 

                GameObject sineObj = Instantiate(obj);
                float newGrassX = this.transform.position.x + x * cellSize + numX;
                float newGrassY = this.transform.position.y + y * cellSize + numY;

                // ���� ��ġ + numX, 0, ������ġ + numZ
                sineObj.transform.position = new Vector3 (newGrassX, 0, newGrassY);
            }
        }
    }
}
using UnityEngine;

namespace CreatureGrove
{
    // �߻� �����ϴ� �׸��� ����
    public class GridManager : MonoBehaviour
    {
        private int gridWidth = 9;    // �׸����� �ʺ�
        private int gridHeight = 8;   // �׸����� ����
        public float cellSize { get; private set; } = 50f; // �� ���� ũ��

        public int[,] gridArray { get; private set; }

        [SerializeField]private GameObject ject;

        void Awake()
        {
            gridArray = new int[gridWidth, gridHeight];

            // "-1" : ����, "0" : �߻�, "1" : �������, "2" : �׿� ����(�̻��)
            #region �׸��� �ʱ�ȭ
            // ��� 0���� �ʱ�ȭ
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    gridArray[x, y] = 0;
                }
            }

            // "-1" : �������� ����
            gridArray[3, 1] = -1;
            gridArray[3, 0] = -1;
            gridArray[4, 1] = -1;
            gridArray[4, 0] = -1;

            // "1" : ������� ����
            gridArray[4, 7] = 1;
            gridArray[4, 6] = 1;
            gridArray[4, 5] = 1;

            gridArray[5, 7] = 1;
            gridArray[5, 6] = 1;
            gridArray[5, 5] = 1;
            gridArray[5, 4] = 1;

            gridArray[6, 7] = 1;
            gridArray[6, 6] = 1;
            gridArray[6, 5] = 1;
            gridArray[6, 4] = 1;
            gridArray[6, 3] = 1;

            gridArray[7, 7] = 1;
            gridArray[7, 6] = 1;
            gridArray[7, 5] = 1;
            gridArray[7, 4] = 1;
            gridArray[7, 3] = 1;
            gridArray[7, 2] = 1;

            gridArray[8, 7] = 1;
            gridArray[8, 6] = 1;
            gridArray[8, 5] = 1;
            gridArray[8, 4] = 1;
            gridArray[8, 3] = 1;
            gridArray[8, 2] = 1;

            // "2" : �� �� ���� ���� 
            gridArray[0, 7] = 2;
            gridArray[1, 7] = 2;
            gridArray[2, 7] = 2;
            gridArray[3, 7] = 2;
            gridArray[8, 0] = 2;
            gridArray[8, 1] = 2;
            #endregion

            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    Vector3 v = GetWorldPosition(x, y);
                    GameObject b = Instantiate(ject);
                    b.transform.position = v;
                }
            }
        }

        // �׸��� ���� ��ǥ�� ���� ��ǥ�� ��ȯ, ������ => (-200,-50)
        public Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x * cellSize + -200, 0, y * cellSize - 50);
        }
    }


}

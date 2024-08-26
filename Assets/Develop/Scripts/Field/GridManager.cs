using UnityEngine;

namespace CreatureGrove
{
    // 야생 구분하는 그리드 생성
    public class GridManager : MonoBehaviour
    {
        private int gridWidth = 9;    // 그리드의 너비
        private int gridHeight = 8;   // 그리드의 높이
        public float cellSize { get; private set; } = 50f; // 각 셀의 크기

        public int[,] gridArray { get; private set; }

        #region 싱글턴
        private static GridManager instance;
        public static GridManager Instance
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
            gridArray = new int[gridWidth, gridHeight];

            // "-1" : 마을, "0" : 야생, "1" : 어둠지역, "2" : 그외 지역(미사용)
            #region 그리드 초기화
            // 모두 0으로 초기화
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    gridArray[x, y] = 0;
                }
            }

            // "-1" : 마을지역 설정
            gridArray[3, 1] = -1;
            gridArray[3, 0] = -1;
            gridArray[4, 1] = -1;
            gridArray[4, 0] = -1;

            // "1" : 어둠지역 설정
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

            // "2" : 그 외 지역 설정 
            gridArray[0, 7] = 2;
            gridArray[1, 7] = 2;
            gridArray[2, 7] = 2;
            gridArray[3, 7] = 2;
            gridArray[8, 0] = 2;
            gridArray[8, 1] = 2;
            #endregion
        }

        // 그리드 상의 좌표를 월드 좌표로 변환, 기준점 => (-200,-50)
        public Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x * cellSize + -200, 0, y * cellSize - 50);
        }
    }
}

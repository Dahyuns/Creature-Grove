using UnityEngine;

namespace CreatureGrove
{
    public enum CharacterType
    {
        Townsfolk,  // 주민(퀘스트X상태)
        Enemy      // 몬스터
    }

    // 필드 - 야생
    // 나무, 잡초 생성 및 관리
    public class Wilderness : MonoBehaviour
    {
        #region 싱글턴
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

        // [씬 로드시, 잡초들 세팅] (마을, 어둠지역 제외하기)
        // 참조
        [SerializeField] private GameObject grass;
        [SerializeField] private GameObject tree;
        [SerializeField] private GameObject rock;

        // 한칸당 유닛의 개수
        private int totalUnits = 10;

        // sin함수 그래프 폭 간격 (커질수록 촘촘해짐, 기본은 1)
        public float cycleMulti = 1;


        public void SetNature()
        {
            int[,] array = GridManager.Instance.gridArray;

            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    // 해당 칸이 야생이라면
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
            // 위에서 아래 x = sin(y)
            // 한 단위당 거리
            float unit = cellSize / totalUnits;

            for (int  i = 0; i < totalUnits; i++)
            {
                float numX = (unit * i) + (unit / 2); 

                // 진폭, 파형의 '높이'(=cellSize의 반) * SIN함수 (드롭 간격 * x값)     + 원점이동값(=cellSize의 반)
                float numY = (cellSize / 2)          * Mathf.Sin(cycleMulti * numX + seed) - cellSize / 2; // 

                GameObject sineObj = Instantiate(obj);
                float newGrassX = this.transform.position.x + x * cellSize + numX;
                float newGrassY = this.transform.position.y + y * cellSize + numY;

                // 시작 위치 + numX, 0, 시작위치 + numZ
                sineObj.transform.position = new Vector3 (newGrassX, 0, newGrassY);
            }
        }
    }
}
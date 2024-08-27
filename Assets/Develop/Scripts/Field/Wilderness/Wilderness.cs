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

        // 참조 (오브젝트 랜덤 반환해주는 함수 추가하기)
        [SerializeField] private GameObject[] grasses;
        [SerializeField] private GameObject[] trees;
        [SerializeField] private GameObject[] rocks;
        [SerializeField] private GameObject[] mushrooms;
        [SerializeField] private GameObject parent;

        // 한칸당 유닛의 개수
        private int totalUnits = 10;
        [SerializeField] private float grassScale = 1;
        [SerializeField] private float treeScale = 1;
        [SerializeField] private float rockScale = 1;
        [SerializeField] private float mushroomScale = 1;

        // sin함수 그래프 폭(주기) 간격 (커질수록 촘촘해짐, 기본은 1)
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
                    // 해당 칸이 야생이라면
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

        // 사인 그래프를 활용하여 오브젝트를 생성 (한칸의 크기, 생성할 오브젝트, x칸 번호, y칸 번호, 랜덤 시드값 (2파이 안으로))
        private void InstantiateSineWaveObject(float cellSize, GameObject[] array, float scale, int x, int y, int seed)
        {
            // 위에서 아래 x = sin(y)
            // 한 단위당 거리
            float unit = cellSize / (totalUnits * scale);

            for (int i = 0; i < (totalUnits * scale); i++)
            {
                float numX = (unit * i) + (unit / 2);

                // 진폭, 파형의 '높이'(=cellSize의 반) * SIN함수 (드롭 간격 * x값)     + 원점이동값(=cellSize의 반)
                float numY = (cellSize / 2) * Mathf.Sin(Mult * numX + seed) - cellSize / 2;

                GameObject sineObj = Instantiate(RandomObj(array), parent.transform);

                float newGrassX = this.transform.position.x + x * cellSize + numX;
                float newGrassY = this.transform.position.y + y * cellSize + numY;

                // 시작 위치 + numX, 0, 시작위치 + numZ
                sineObj.transform.position = new Vector3(newGrassX, 0, newGrassY);
            }
        }

        // 인스펙터 창 내 배열에서 랜덤한 오브젝트 반환
        private GameObject RandomObj(GameObject[] array)
        {
            int i = Random.Range(0, array.Length);

            return array[i];
        }
    }
}
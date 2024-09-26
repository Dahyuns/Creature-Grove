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

        // 참조 (묶음 순서대로 자연, 적, 부모)
        [SerializeField] private GameObject[] grasses;
        [SerializeField] private GameObject[] trees;
        [SerializeField] private GameObject[] rocks;
        [SerializeField] private GameObject[] mushrooms;

        [SerializeField] private GameObject[] FieldEnemys;
        [SerializeField] private GameObject WayPoints;

        [SerializeField] private GameObject Natureparent;
        [SerializeField] private GameObject Enemysparent;
        [SerializeField] private GameObject Pointsparent;

        // 한칸당 유닛의 개수
        private int totalUnits = 10;
        [SerializeField] private float grassScale = 1;
        [SerializeField] private float treeScale = 1;
        [SerializeField] private float rockScale = 1;
        [SerializeField] private float mushroomScale = 1;

        // sin함수 그래프 폭(주기) 간격 (커질수록 촘촘해짐, 기본은 1)
        [SerializeField] private float Mult = 1;

        // 0~100 까지 퍼센티지
        [SerializeField] private int Chance = 100;

        // 확률 계산 (for 생성)
        private bool MakeChance()
        {
            int RanNum = Random.Range(0, 101); // 0 ~ 100

            if (RanNum <= Chance) 
            { return true; }
            else 
            { return false; }
        }


        private void Start()
        {
            SetNature();
        }

        // "-1" : 마을, "0" : 야생, "1" : 어둠지역, "2" : 그외 지역(미사용)
        private void SetNature()
        {
            int[,] array = GridManager.Instance.gridArray;

            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    if (array[x, y] == 0)
                    {
                        InstantiateSineWaveObject(mushrooms, mushroomScale, x, y, 0);
                        InstantiateSineWaveObject(grasses, grassScale, x, y, 2);
                        InstantiateSineWaveObject(trees, treeScale, x, y, 3);
                        InstantiateSineWaveObject(rocks, rockScale, x, y, 4);
                        InstantiateEnemy(x, y);
                    }
                }
            }
        }

        // 사인 그래프를 활용하여 오브젝트를 생성 (한칸의 크기, 생성할 오브젝트, x칸 번호, y칸 번호, 랜덤 시드값 (2파이 안으로))
        private void InstantiateSineWaveObject(GameObject[] array, float scale, int x, int y, int seed)
        {
            float cellSize = GridManager.Instance.cellSize;
            // 위에서 아래 x = sin(y)
            // 한 단위당 거리
            float unit = cellSize / (totalUnits * scale);

            for (int i = 0; i < (totalUnits * scale); i++)
            {
                float numX = (unit * i) + (unit / 2);

                // 진폭, 파형의 '높이'(=cellSize의 반) * SIN함수 (드롭 간격 * x값)     + 원점이동값(=cellSize의 반)
                float numY = (cellSize / 2) * Mathf.Sin(Mult * numX + seed) - cellSize / 2;

                GameObject sineObj = Instantiate(RandomObj(array), Natureparent.transform);

                float newGrassX = this.transform.position.x + x * cellSize + numX;
                float newGrassY = this.transform.position.y + y * cellSize + numY;

                // 시작 위치 + numX, 0, 시작위치 + numZ
                sineObj.transform.position = new Vector3(newGrassX, 0, newGrassY);
            }
        }

        // Enemy(FieldEnemy) 생성
        private void InstantiateEnemy(int x, int y)
        {
            if (MakeChance() == false) return;

            // 생성
            GameObject fEnemy = Instantiate(RandomObj(FieldEnemys), Enemysparent.transform);
            GameObject Points = Instantiate(WayPoints, Pointsparent.transform);

            // 위치 지정
            fEnemy.transform.position = GridManager.Instance.GetWorldPosition(x, y);
            Points.transform.position = fEnemy.transform.position;

            // (스크립트에서) 연결시키기
            fEnemy.GetComponent<FieldEnemyBehavior>().ConnectWayPoints(Points);
        }

        // 인스펙터 창 내 배열에서 랜덤한 오브젝트 반환
        private GameObject RandomObj(GameObject[] array)
        {
            int i = Random.Range(0, array.Length);

            return array[i];
        }
    }
}
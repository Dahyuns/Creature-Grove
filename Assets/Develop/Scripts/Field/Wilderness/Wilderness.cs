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
            #endregion

            // 이거 씬에서 만들어야함
            basePos = GameObject.Find("basePos").transform.position;
        }

        // [씬 로드시, 잡초들 세팅] (마을, 어둠지역 제외하기)
        [SerializeField] private GameObject grass;
        private GameObject TownZone;
        private GameObject DarkZone;

        // 왼쪽아래 기준 좌표
        private Vector3 basePos;

        // sin함수 x좌표 간격 
        private float unit = 5f;


        public void SetGrass()
        {
            Instantiate(grass, this.transform);

            //필드 드롭 간격 (커질수록 촘촘해짐, 기본은 1)
            //private float cycleMulti = 1;
            // 진폭, 파형의 '높이'(=z의 반) * SIN함수 (드롭 간격 * x값) + 원점이동값(=z의 반)
            //float numX = unit * i;
            //float numZ = z / 2 * Mathf.Sin(cycleMulti * numX) + z / 2;
        }

    }
}
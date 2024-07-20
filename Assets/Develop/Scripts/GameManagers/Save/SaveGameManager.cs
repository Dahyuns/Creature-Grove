using UnityEngine;

namespace CreatureGrove
{
    public class SaveGameManager : MonoBehaviour, ISaveLoadManager
    {
        private static SaveGameManager instance;
        public static SaveGameManager Instance
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

        // 플레이어 관련
        private int playerLV;
        private WeaponType playerWeapon;

        // 맵 관련
        private Vector2[] mapINFO;
        private int[] villagerList;
        private int[] buildingList;

        // 몬스터 레벨 관련
        private int mWaveLV;
        private int bossLV;

        // [ISaveLoadManager]
        public void Save()
        {

        }
    }
}
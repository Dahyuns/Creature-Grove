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

        // �÷��̾� ����
        private int playerLV;
        private WeaponType playerWeapon;

        // �� ����
        private Vector2[] mapINFO;
        private int[] villagerList;
        private int[] buildingList;

        // ���� ���� ����
        private int mWaveLV;
        private int bossLV;

        // [ISaveLoadManager]
        public void Save()
        {

        }
    }
}
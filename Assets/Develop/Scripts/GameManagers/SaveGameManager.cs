using System.Collections.Generic;
using UnityEngine;

namespace CreatureGrove
{
    public enum SaveType
    {
        PLAYER,
        ENEMY,
        TOWNFOLK,
        TOWN,
        ITEM,
        FIELD
    }

    public class SaveGameManager : MonoBehaviour
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

        // [ISaveLoadManager] : Composite ,Visitor  ���� ���?
        public void Save(SaveType type)
        {
            switch (type)
            {
                case SaveType.PLAYER:
                    break;

                case SaveType.ENEMY:
                    break;

                case SaveType.TOWNFOLK:
                    break;

                case SaveType.TOWN:
                    break; 

                case SaveType.ITEM:
                    break;

                case SaveType.FIELD:
                    break;

                default:
                    break;
            }


        }
    }
}
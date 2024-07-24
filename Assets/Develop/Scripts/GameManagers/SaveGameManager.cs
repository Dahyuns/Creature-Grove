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

        // [ISaveLoadManager] : Composite ,Visitor  패턴 사용?
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
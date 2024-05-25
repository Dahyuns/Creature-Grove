using UnityEngine;

namespace CreatureGrove
{
    public class Player : MonoBehaviour
    {
        // 참조
        [SerializeField] private GameObject GunPrefab;
        [SerializeField] private GameObject BowPrefab;

        private GameObject thisWeapon;

        private static WeaponType weaponType;
        public static WeaponType WeaponType { get { return weaponType; } }
        private float hp;
        private float currentWeight;
        private float stamina;


        private void Awake()
        {
            weaponType = WeaponType.Bow;
            switch (weaponType)
            {
                case WeaponType.Gun:
                    thisWeapon = Instantiate(GunPrefab, transform);
                    break;

                case WeaponType.Bow:
                    thisWeapon = Instantiate(BowPrefab, transform);
                    break;
            }
            Debug.Log(thisWeapon);
        }


        // Attack은 Weapon으로만 가능
        public void TakeDamage(float enemyAtk)
        {
            hp -= enemyAtk;
        }
    }
}
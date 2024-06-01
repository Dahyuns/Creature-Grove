using UnityEngine;

namespace CreatureGrove
{
    public class Player : MonoBehaviour
    {
        // ����
        [SerializeField] private GameObject GunPrefab;
        [SerializeField] private GameObject BowPrefab;

        private GameObject thisWeapon;
        public GameObject Thisweapon
        {
            get { return thisWeapon; }
        }

        private WeaponType weaponType = WeaponType.Bow;
        public WeaponType WeaponType { get { return weaponType; } }

        private float hp;
        private float currentWeight;
        private float stamina;


        private void Awake()
        {
            switch (weaponType)
            {
                case WeaponType.Gun:
                    thisWeapon = Instantiate(GunPrefab, transform);
                    break;

                case WeaponType.Bow:
                    thisWeapon = Instantiate(BowPrefab, transform);
                    break;
            }
        }


        // Attack�� Weapon���θ� ����
        public void TakeDamage(float enemyAtk)
        {
            hp -= enemyAtk;
        }
    }
}
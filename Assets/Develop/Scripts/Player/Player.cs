using UnityEngine;

namespace CreatureGrove
{
    public class Player : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager, IItemManager, ISaveLoadManager
    {
        // 참조
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


        // Attack은 Weapon으로만 가능
        public void gTakeDamage(float enemyAtk)
        {
            hp -= enemyAtk;
        }


        // [ICraftingManager]
        public void createItem(ItemType type)
        {

        }


        // [IDamageManager]
        public void Attack(IDamageManager target, float amount)
        {

        }

        public void TakeDamage(float amount)
        {

        }


        // [IFieldItemManager]
        public void PerformAction(FieldAction action)
        {

        }


        // [IItemManager]
        public void Equip()
        {

        }

        public void Unequip()
        {

        }


        // [ISaveLoadManager]
        public void Save()
        {

        }

    }
}
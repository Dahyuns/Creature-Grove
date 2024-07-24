using UnityEngine;

namespace CreatureGrove
{
    public class Player : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager
    {
        // 참조
        [SerializeField] private GameObject GunPrefab;
        [SerializeField] private GameObject BowPrefab;

        private Inventory inventory;

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
            inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

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

        // [ICraftingManager]
        public void createItem(ItemType type)
        {

        }


        // [IDamageManager]
        public void Attack(GameObject target, float amount) // 무기에서 호출?
        {
            Enemy enemy = target.GetComponent<Enemy>();
            enemy.TakeDamage(amount);
        }


        private bool isDead = false;
        public bool IsDead
        {
            get { return isDead; }
        }

        public void TakeDamage(float amount)
        {
            if (hp - amount >= 0)
            {
                hp -= amount;
            }
            else
            {
                hp = 0;

                // 죽음
                isDead = true;

                // 죽음 방송, 브로드캐스팅, Gameover or Respawn
            }
        }

        // [IFieldItemManager]
        public void PerformAction(FieldAction action, ItemType itemType)
        {
            switch (action)
            {
                case FieldAction.harvestItem:

                    break;
                case FieldAction.PickUpItem:
                    //inventory.
                    break;
                case FieldAction.DropItem:
                    break;
            }
        }
    }
}
/*
        harvestItem, // 채집

        PickUpItem,  // 필드에 떨어진 아이템 수집
        DropItem     // 필드에 아이템 떨어트림  */
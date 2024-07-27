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

        private Weapon weapon;

        private string weaponTag = "Weapon";

        private float hp;
        public float HP
        {
            get => hp;
        }

        private float currentWeight; // 인벤토리 용량
        private float stamina; // 기력

        private void Awake()
        {
            // 무기 태그를 가진 오브젝트를 찾음
            thisWeapon = GameObject.FindGameObjectWithTag(weaponTag);
            // 무기오브젝트의 클래스를 업캐스팅
            switch (Weapon.weaponType)
            {
                case WeaponType.Gun:
                    weapon = thisWeapon.GetComponent<Gun>();
                    break;

                case WeaponType.Bow:
                    weapon = thisWeapon.GetComponent<Bow>();
                    break;
            }


            // 인벤토리 
            inventory = GameObject.Find("Inventory").GetComponent<Inventory>();


            /*
            switch (weaponType)
            {
                case WeaponType.Gun:
                    thisWeapon = Instantiate(GunPrefab, transform);
                    break;

                case WeaponType.Bow:
                    thisWeapon = Instantiate(BowPrefab, transform);
                    break;
            }*/
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
                    // 인벤토리에 추가
                    inventory.addToInventory(itemType);

                    // 필드에서 삭제

                    break;

                case FieldAction.DropItem:
                    // 인벤토리에서 삭제
                    inventory.removeFromInventory(itemType);

                    // 필드에 생성(해당좌표, 해당 아이템)

                    break;
            }
        }
    }
}
/*
        harvestItem, // 채집

        PickUpItem,  // 필드에 떨어진 아이템 수집
        DropItem     // 필드에 아이템 떨어트림  */
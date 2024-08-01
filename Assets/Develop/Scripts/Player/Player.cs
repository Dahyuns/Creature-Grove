using UnityEngine;

namespace CreatureGrove
{
    public class Player : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager
    {
        // 참조
        [SerializeField] private GameObject GunPrefab;
        [SerializeField] private GameObject BowPrefab;

        // 여기서 무기 생성? 
        private void Awake()
        {
            // 무기
            Weapon.weaponType = WeaponType.Gun;
            switch (Weapon.weaponType)
            {
                case WeaponType.Gun:
                    Instantiate(GunPrefab,this.transform);
                    break;
                    

                case WeaponType.Bow:
                    Instantiate(BowPrefab, this.transform);
                    break;
            }


            // 인벤토리 
            inventory = GameObject.Find(GameStrings.Inventory)?.GetComponent<Inventory>();
        }
      

        private Inventory inventory;

        private float hp;
        public float HP
        {
            get => hp;
        }
        
        private float currentWeight; // 인벤토리 용량
        private float stamina; // 기력

        // [ICraftingManager]
        public void createItem(ItemType type)
        {

        }


        // [IDamageManager]
        public void Attack(GameObject target, float amount) // 총알에서 호출?
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
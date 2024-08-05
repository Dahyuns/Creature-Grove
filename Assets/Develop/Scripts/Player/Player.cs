using UnityEngine;

namespace CreatureGrove
{
    public class Player : MonoBehaviour, ICraftingManager, IDamageManager
    {
        // 참조
        [SerializeField] private GameObject GunPrefab;
        [SerializeField] private GameObject BowPrefab;

        private void Awake()
        {
            // [임시] 무기 결정
            Weapon.weaponType = WeaponType.Gun;

            // 무기 생성
            switch (Weapon.weaponType)
            {
                case WeaponType.Gun:
                    Instantiate(GunPrefab,this.transform);
                    break;
                    

                case WeaponType.Bow:
                    Instantiate(BowPrefab, this.transform);
                    break;
            }


            // [임시] 인벤토리 찾기
            // inventory = GameObject.Find(GameStrings.Inventory)?.GetComponent<Inventory>();
        }
      

        private float hp;
        public float HP
        {
            get => hp;
        }
        
        private float currentWeight; // 인벤토리 용량
        private float stamina; // 기력



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [ICraftingManager]
        public void createItem(Item item)
        {

        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [IDamageManager]
        private bool isDead = false;
        public bool IsDead
        {
            get { return isDead; }
        }

        public void Attack(IDamageManager target, float amount)
        {
            target.TakeDamage(amount);
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

                // 죽음 방송, 브로드캐스팅, GameOver or Respawn
            }
        }



        /*
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [IFieldItemManager]
        public void PerformAction(FieldAction action, Item item)
        {
            switch (action)
            {
                case FieldAction.harvestItem:

                    break;
                case FieldAction.PickUpItem:
                    // 인벤토리에 추가
                    // inventory.addToInventory(itemType);

                    // 필드에서 삭제

                    break;

                case FieldAction.DropItem:
                    // 인벤토리에서 삭제
                    // inventory.removeFromInventory(itemType);

                    // 필드에 생성(해당좌표, 해당 아이템)

                    break;
            }
        }
        */
    }
}
/*
        harvestItem, // 채집

        PickUpItem,  // 필드에 떨어진 아이템 수집
        DropItem     // 필드에 아이템 떨어트림  */
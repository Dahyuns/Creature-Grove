using UnityEngine;

namespace CreatureGrove
{
    public class Player : MonoBehaviour, ICraftingManager, IDamageManager
    {
        // ����
        [SerializeField] private GameObject GunPrefab;
        [SerializeField] private GameObject BowPrefab;

        private void Awake()
        {
            // [�ӽ�] ���� ����
            Weapon.weaponType = WeaponType.Gun;

            // ���� ����
            switch (Weapon.weaponType)
            {
                case WeaponType.Gun:
                    Instantiate(GunPrefab,this.transform);
                    break;
                    

                case WeaponType.Bow:
                    Instantiate(BowPrefab, this.transform);
                    break;
            }


            // [�ӽ�] �κ��丮 ã��
            // inventory = GameObject.Find(GameStrings.Inventory)?.GetComponent<Inventory>();
        }
      

        private float hp;
        public float HP
        {
            get => hp;
        }
        
        private float currentWeight; // �κ��丮 �뷮
        private float stamina; // ���



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

                // ����
                isDead = true;

                // ���� ���, ��ε�ĳ����, GameOver or Respawn
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
                    // �κ��丮�� �߰�
                    // inventory.addToInventory(itemType);

                    // �ʵ忡�� ����

                    break;

                case FieldAction.DropItem:
                    // �κ��丮���� ����
                    // inventory.removeFromInventory(itemType);

                    // �ʵ忡 ����(�ش���ǥ, �ش� ������)

                    break;
            }
        }
        */
    }
}
/*
        harvestItem, // ä��

        PickUpItem,  // �ʵ忡 ������ ������ ����
        DropItem     // �ʵ忡 ������ ����Ʈ��  */
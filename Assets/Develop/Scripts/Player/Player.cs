using UnityEngine;

namespace CreatureGrove
{
    public class Player : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager
    {
        // ����
        [SerializeField] private GameObject GunPrefab;
        [SerializeField] private GameObject BowPrefab;

        private Inventory inventory;

        private float hp;
        public float HP
        {
            get => hp;
        }
        
        private float currentWeight; // �κ��丮 �뷮
        private float stamina; // ���

        private void Awake()
        {
            // �κ��丮 
            inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        }

        // [ICraftingManager]
        public void createItem(ItemType type)
        {

        }


        // [IDamageManager]
        public void Attack(GameObject target, float amount) // ���⿡�� ȣ��?
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

                // ����
                isDead = true;

                // ���� ���, ��ε�ĳ����, Gameover or Respawn
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
                    // �κ��丮�� �߰�
                    inventory.addToInventory(itemType);

                    // �ʵ忡�� ����

                    break;

                case FieldAction.DropItem:
                    // �κ��丮���� ����
                    inventory.removeFromInventory(itemType);

                    // �ʵ忡 ����(�ش���ǥ, �ش� ������)

                    break;
            }
        }
    }
}
/*
        harvestItem, // ä��

        PickUpItem,  // �ʵ忡 ������ ������ ����
        DropItem     // �ʵ忡 ������ ����Ʈ��  */
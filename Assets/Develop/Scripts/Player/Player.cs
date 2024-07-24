using UnityEngine;

namespace CreatureGrove
{
    public class Player : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager
    {
        // ����
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
                    //inventory.
                    break;
                case FieldAction.DropItem:
                    break;
            }
        }
    }
}
/*
        harvestItem, // ä��

        PickUpItem,  // �ʵ忡 ������ ������ ����
        DropItem     // �ʵ忡 ������ ����Ʈ��  */
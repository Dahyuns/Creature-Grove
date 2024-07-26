using UnityEngine;

namespace CreatureGrove
{
    public class Player : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager
    {
        // ÂüÁ¶
        [SerializeField] private GameObject GunPrefab;
        [SerializeField] private GameObject BowPrefab;

        private Inventory inventory;

        private GameObject thisWeapon;
        public GameObject Thisweapon
        {
            get { return thisWeapon; }
        }

        private Weapon weapon;

        private string weaponTag = "Weapon";

        private float hp;
        private float currentWeight;
        private float stamina;


        private void Awake()
        {
            // ï¿½ï¿½ï¿½ï¿½ ï¿½Â±×¸ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ®ï¿½ï¿½ Ã£ï¿½ï¿½
            thisWeapon = GameObject.FindGameObjectWithTag(weaponTag);
            // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ®ï¿½ï¿½ Å¬ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½Ä³ï¿½ï¿½ï¿½ï¿½
            switch (Weapon.weaponType)
            {
                case WeaponType.Gun:
                    weapon = thisWeapon.GetComponent<Gun>();
                    break;

                case WeaponType.Bow:
                    weapon = thisWeapon.GetComponent<Bow>();
                    break;
            }


            // ï¿½Îºï¿½ï¿½ä¸® 
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
        public void Attack(GameObject target, float amount) // ¹«±â¿¡¼­ È£Ãâ?
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

                // Á×À½
                isDead = true;

                // Á×À½ ¹æ¼Û, ºê·ÎµåÄ³½ºÆÃ, Gameover or Respawn
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
        harvestItem, // Ã¤Áý

        PickUpItem,  // ÇÊµå¿¡ ¶³¾îÁø ¾ÆÀÌÅÛ ¼öÁý
        DropItem     // ÇÊµå¿¡ ¾ÆÀÌÅÛ ¶³¾îÆ®¸²  */
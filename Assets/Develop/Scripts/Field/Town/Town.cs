using UnityEngine;

namespace CreatureGrove
{
    public class Town : MonoBehaviour, ICraftingManager, IDamageManager, IItemManager
    {
        #region 싱글턴
        private static Town instance;
        public static Town Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }
            DestroyImmediate(gameObject);

            buildings = GameObject.Find(strBuilding).GetComponentsInChildren<Building>();

            foreach (Building buil in buildings)
            {
                buil.SetName(buil.gameObject.name);
                buil.SetLevel(0);
            }
        }
        #endregion

        // 건물 리스트
        private string strBuilding = "Building";
        private Building[] buildings;
        // buildings[i].Name

        // [ICraftingManager] :  마을 제작대에서 제작 가능
        public void createItem(Item item)
        {

        }

        // [IDamageManager] : 성벽, 타워 등 방어 가능성
        public void Attack(IDamageManager target, float amount)
        {
            target.TakeDamage(amount);
        }

        public void TakeDamage(float amount)
        {

        }

        // [IItemManager]
        public void Equip()
        {

        }

        public void Unequip()
        {

        }
    }
}
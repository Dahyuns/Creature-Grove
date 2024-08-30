using UnityEngine;

namespace CreatureGrove
{
    public class Town : MonoBehaviour, ICraftingManager, IDamageManager, IItemManager
    {
        #region �̱���
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

        // �ǹ� ����Ʈ
        private string strBuilding = "Building";
        private Building[] buildings;
        // buildings[i].Name

        // [ICraftingManager] :  ���� ���۴뿡�� ���� ����
        public void createItem(Item item)
        {

        }

        // [IDamageManager] : ����, Ÿ�� �� ��� ���ɼ�
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
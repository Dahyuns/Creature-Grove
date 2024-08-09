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
        }
        #endregion

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
using UnityEngine;

namespace CreatureGrove
{
    public class Town : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager, IItemManager
    {
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


        // [IFieldItemManager]
        public void PerformAction(FieldAction action, Item item)
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
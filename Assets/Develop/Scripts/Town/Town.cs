using UnityEngine;

namespace CreatureGrove
{
    public class Town : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager, IItemManager
    {
        // [ICraftingManager] :  ���� ���۴뿡�� ���� ����
        public void createItem(ItemType type)
        {

        }


        // [IDamageManager] : ����, Ÿ�� �� ��� ���ɼ�
        public void Attack(GameObject target, float amount)
        {

        }

        public void TakeDamage(float amount)
        {

        }


        // [IFieldItemManager]
        public void PerformAction(FieldAction action, ItemType itemType)
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
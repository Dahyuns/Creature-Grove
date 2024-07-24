using UnityEngine;

namespace CreatureGrove
{
    public class Town : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager, IItemManager
    {
        // [ICraftingManager] :  마을 제작대에서 제작 가능
        public void createItem(ItemType type)
        {

        }


        // [IDamageManager] : 성벽, 타워 등 방어 가능성
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
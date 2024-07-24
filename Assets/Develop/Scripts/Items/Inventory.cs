using UnityEngine;

namespace CreatureGrove
{
    public class Inventory : MonoBehaviour, IFieldItemManager, IItemManager
    {
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
using UnityEngine;

namespace CreatureGrove
{
    public class Inventory : MonoBehaviour, IFieldItemManager, IItemManager
    {
        #region �̱���


        #endregion


        // �κ��丮�� ���
        public void addToInventory(ItemType itemType)
        {

        }
        
        // �κ��丮���� ����
        public void removeFromInventory(ItemType itemType) 
        {
                    
        }


        // [IFieldItemManager]
        public void PerformAction(FieldAction action, ItemType itemType)
        {

        }

        // [IItemManager]
        // ����
        public void Equip()
        {

        }

        // ����
        public void Unequip()
        {

        }
    }
}
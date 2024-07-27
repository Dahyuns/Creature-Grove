using UnityEngine;

namespace CreatureGrove
{
    public class Inventory : MonoBehaviour, IFieldItemManager, IItemManager
    {
        #region 싱글턴


        #endregion


        // 인벤토리에 등록
        public void addToInventory(ItemType itemType)
        {

        }
        
        // 인벤토리에서 삭제
        public void removeFromInventory(ItemType itemType) 
        {
                    
        }


        // [IFieldItemManager]
        public void PerformAction(FieldAction action, ItemType itemType)
        {

        }

        // [IItemManager]
        // 장착
        public void Equip()
        {

        }

        // 해제
        public void Unequip()
        {

        }
    }
}
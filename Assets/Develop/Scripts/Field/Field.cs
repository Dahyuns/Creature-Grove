using UnityEngine;
/*      harvestItem, // 채집

        PickUpItem,  // 필드에 떨어진 아이템 수집
        DropItem     // 필드에 아이템 떨어트림  */
namespace CreatureGrove
{
    public class Field : MonoBehaviour, ICharacterCreationManager
    {
        #region 싱글턴
        private static Field instance;
        public static Field Instance
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
            #endregion
        }


        // 필드에 추가 (해당 위치, 해당 아이템)
        public void PerformAction(FieldAction action, GameObject item)
        {
            Item i = item.GetComponent<Item>();
            switch (action)
            {
                case FieldAction.harvestItem:
                    // 인벤토리에 추가
                    Inventory.Instance.addToInventory(i);
                    // 필드에서 삭제
                    Destroy(item);

                    break;
                case FieldAction.PickUpItem:
                    // 인벤토리에 추가
                    Inventory.Instance.addToInventory(i);

                    // 필드에서 삭제
                    Destroy(item);

                    break;

                case FieldAction.DropItem:
                    // 인벤토리에서 삭제
                    Inventory.Instance.removeFromInventory(i);

                    // 필드에 생성(해당좌표, 해당 아이템)

                    break;
            }
        }

        // [ICharacterCreationManager]
        public void CreatCharacter(CharacterType type)
        {

        }
    }
}
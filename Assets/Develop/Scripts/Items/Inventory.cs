using UnityEngine;

namespace CreatureGrove
{
    public class Inventory : MonoBehaviour
    {
        // 인벤토리 저장칸 (수정은 이 안에서만)
        private Item[] items;
        public Item[] Items { get { return items; } }

        // 인벤토리에 저장되어있는 아이템들의 ID
        private string[] ids;

        // null방지
        private Item nullItem;

        #region 싱글턴
        private static Inventory instance;
        public static Inventory Instance
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
            for (int i = 0; i < items.Length; i++)
            {
                if (ItemController.Instance.itemList.items[i] != null)
                {
                    items[i] = ItemController.Instance.itemList.items[i];
                    continue;
                }
                items[i] = nullItem;
            }
        }

        // 해당 아이템을 인벤토리에 등록 (마지막칸에? 배열인데 어케하쥐)
        public void addToInventory(Item item) 
        {
            int blank = items.Length;
            for (int i = 0; i < items.Length; i++)
            {
                // 같은 아이템 등록시 +1
                if (items[i] == item)
                {
                    items[i].amount += 1;
                    return;
                }

                // 없는 아이템 등록시
                // 빈칸 체크 (빈칸이 더 뒤에 있을때만)
                if (blank > i && items[i] == nullItem)
                {
                    blank = i;
                }
            }
            // 가장 앞에 있는 빈칸에 아이템 추가
            items[blank] = item; 
        }

        // 해당 아이템을 인벤토리에서 삭제
        public void removeFromInventory(Item item) 
        { 
            for (int i = 0; i < items.Length; i++) 
            {
                if (items[i] == item)
                {
                    items[i] = nullItem;
                    return;
                }
            }
        }
    }
}
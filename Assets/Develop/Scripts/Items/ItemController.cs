using CreatureGrove;
using UnityEngine;

namespace CreatureGrove
{
    // 아이템 불러오기 
    // Item item = ItemController.Instance.GetItemById("ITEM001");

    public class ItemController : MonoBehaviour
    {
        #region 싱글턴
        public static ItemController Instance { get; private set; }

        void Start()
        {
            if (Instance != null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        #endregion
            LoadItems();
        }

        public ItemList itemList;
        private Item tmpItem;

        // JSON 파일을 로드하여 ItemList를 초기화
        void LoadItems()
        {
            TextAsset jsonTextFile = Resources.Load<TextAsset>("items");
            if (jsonTextFile != null)
            {
                // JSON 데이터를 ItemList 객체로 변환
                itemList = JsonUtility.FromJson<ItemList>(jsonTextFile.text);

                /* 아이템 데이터를 출력 (디버깅용)
                 (Item item in itemList.items)
                {
                    Debug.Log("ID: " + item.id + ", Name: " + item.name + ", Type: " + item.type);
                }*/
            }
            else
            {
                Debug.LogError("Failed to load the JSON file.");
            }
        }

        public Item GetItemById(string id)
        {
            if (itemList == null)
            {
                Debug.LogError("ItemList is null");
                return tmpItem;
            }

            foreach (Item item in itemList.items)
            {
                if (item.id == id)
                {
                    return item;
                }
            }

            Debug.LogWarning($"Item with ID {id} not found");
            return tmpItem;
        }
    }
}
using CreatureGrove;
using UnityEngine;

namespace CreatureGrove
{
    // ������ �ҷ����� 
    // Item item = ItemController.Instance.GetItemById("ITEM001");

    public class ItemController : MonoBehaviour
    {
        #region �̱���
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

        // JSON ������ �ε��Ͽ� ItemList�� �ʱ�ȭ
        void LoadItems()
        {
            TextAsset jsonTextFile = Resources.Load<TextAsset>("items");
            if (jsonTextFile != null)
            {
                // JSON �����͸� ItemList ��ü�� ��ȯ
                itemList = JsonUtility.FromJson<ItemList>(jsonTextFile.text);

                /* ������ �����͸� ��� (������)
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
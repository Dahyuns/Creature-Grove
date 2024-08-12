using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace CreatureGrove
{
    public class Inventory : MonoBehaviour
    {
        // 인벤토리 저장칸 (수정은 이 안에서만)
        private Item[] items;
        public Item[] Items { get { return items; } }

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
            items = ItemController.Instance.itemList.items;
        }

        // 인벤토리에 등록
        //public void addToInventory(Item item) { items.Add(item); }

        // 인벤토리에서 삭제
        //public void removeFromInventory(Item item) { items.Remove(item); }
    }

    public class UIInventory : MonoBehaviour
    {
        public Image[] uiImage;

        // Inventory Panel
        [SerializeField] private RectTransform panel;

        private void SetInventory()
        {
            panel = GetComponent<RectTransform>();

            for (int i = 0; i < Inventory.Instance.Items.Length; i++)
            {
                foreach (var item in Inventory.Instance.Items)
                {
                    LoadImage(item.id,i);
                }
            }
        }

        public void LoadImage(string id, int num)
        {
            string path = ItemController.Instance.GetItemById(id).path;
            if (string.IsNullOrEmpty(path) == false)
            {
                // 경로를 통해 이미지 로드
                Texture2D texture = Resources.Load<Texture2D>(path);
                if (texture != null)
                {
                    // 텍스처를 Sprite로 변환하여 UI 이미지에 적용
                    uiImage[num].sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                }
                else
                {
                    Debug.LogError("Failed to load the image at path: " + path);
                }
            }
            else
            {
                Debug.LogError("Item ID not found: " + id);
            }
        }
    }
}
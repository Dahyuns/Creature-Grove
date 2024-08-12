using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace CreatureGrove
{
    public class Inventory : MonoBehaviour
    {
        // �κ��丮 ����ĭ (������ �� �ȿ�����)
        private Item[] items;
        public Item[] Items { get { return items; } }

        #region �̱���
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

        // �κ��丮�� ���
        //public void addToInventory(Item item) { items.Add(item); }

        // �κ��丮���� ����
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
                // ��θ� ���� �̹��� �ε�
                Texture2D texture = Resources.Load<Texture2D>(path);
                if (texture != null)
                {
                    // �ؽ�ó�� Sprite�� ��ȯ�Ͽ� UI �̹����� ����
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
using UnityEngine;
using UnityEngine.UI;

namespace CreatureGrove
{
    public class UIInventory : MonoBehaviour
    {
        public Image[] uiImages;

        // Inventory Panel
        [SerializeField] private RectTransform panel;

        public void SetInventory()
        {
            panel = GetComponent<RectTransform>();

            int i = 0;

            // "�κ��丮 ���� ������"�� ������� �����ͼ�, �̹����� �߰����� (�ٵ� �θ� �ؿ��� ���� ����?
            foreach (var item in Inventory.Instance.Items)
            {
                LoadImage(item.id, i++);
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
                    uiImages[num].sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
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
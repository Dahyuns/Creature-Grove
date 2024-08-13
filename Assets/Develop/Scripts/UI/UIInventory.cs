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

            // "인벤토리 내의 아이템"을 순서대로 가져와서, 이미지를 추가해줌 (근데 부모 밑에는 어케 하지?
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
                // 경로를 통해 이미지 로드
                Texture2D texture = Resources.Load<Texture2D>(path);
                if (texture != null)
                {
                    // 텍스처를 Sprite로 변환하여 UI 이미지에 적용
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
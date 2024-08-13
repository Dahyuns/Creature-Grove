using UnityEngine;

namespace CreatureGrove
{
    public class Inventory : MonoBehaviour
    {
        // �κ��丮 ����ĭ (������ �� �ȿ�����)
        private Item[] items;
        public Item[] Items { get { return items; } }

        // �κ��丮�� ����Ǿ��ִ� �����۵��� ID
        private string[] ids;

        // null����
        private Item nullItem;

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

        // �ش� �������� �κ��丮�� ��� (������ĭ��? �迭�ε� ��������)
        public void addToInventory(Item item) 
        {
            int blank = items.Length;
            for (int i = 0; i < items.Length; i++)
            {
                // ���� ������ ��Ͻ� +1
                if (items[i] == item)
                {
                    items[i].amount += 1;
                    return;
                }

                // ���� ������ ��Ͻ�
                // ��ĭ üũ (��ĭ�� �� �ڿ� ��������)
                if (blank > i && items[i] == nullItem)
                {
                    blank = i;
                }
            }
            // ���� �տ� �ִ� ��ĭ�� ������ �߰�
            items[blank] = item; 
        }

        // �ش� �������� �κ��丮���� ����
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
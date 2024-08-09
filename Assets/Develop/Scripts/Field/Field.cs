using UnityEngine;
/*      harvestItem, // ä��

        PickUpItem,  // �ʵ忡 ������ ������ ����
        DropItem     // �ʵ忡 ������ ����Ʈ��  */
namespace CreatureGrove
{
    public class Field : MonoBehaviour
    {
        #region �̱���
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
        }
        #endregion

        // �ʵ忡 �߰� (�ش� ��ġ, �ش� ������)
        public void PerformAction(FieldAction action, Item item)
        {
            switch (action)
            {
                case FieldAction.harvestItem:
                    // �κ��丮�� �߰�
                    Inventory.Instance.addToInventory(item);
                    // �ʵ忡�� ����


                    break;
                case FieldAction.PickUpItem:
                    // �κ��丮�� �߰�
                    Inventory.Instance.addToInventory(item);

                    // �ʵ忡�� ����

                    break;

                case FieldAction.DropItem:
                    // �κ��丮���� ����
                    Inventory.Instance.removeFromInventory(item);

                    // �ʵ忡 ����(�ش���ǥ, �ش� ������)

                    break;
            }
        }

        // �ʵ忡�� ����
    }
}
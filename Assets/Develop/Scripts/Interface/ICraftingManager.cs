namespace CreatureGrove
{
    public enum ItemType   // �ӽ��׸�
    {
        WEAPON,            // ����
        BUILDING_MATERIAL, // ���� ���
        TOOL,              // ����
        CONSUMABLE,        // �Ҹ�ǰ
        ARMOR,             // ��
        ACCESSORY          // �׼�����
    }

    public interface ICraftingManager
    {
        void createItem(ItemType type);
    }
}
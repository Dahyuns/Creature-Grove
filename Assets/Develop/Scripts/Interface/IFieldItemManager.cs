namespace CreatureGrove
{
    public enum FieldAction
    {
        harvestItem, // ä��

        PickUpItem,  // �ʵ忡 ������ ������ ����
        DropItem     // �ʵ忡 ������ ����Ʈ��
    }


    public interface IFieldItemManager
    {
        void PerformAction(FieldAction action);
    }
}
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
        public void PerformAction(FieldAction action);
    }
}
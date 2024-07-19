namespace CreatureGrove
{
    public enum FieldAction
    {
        harvestItem, // 채집

        PickUpItem,  // 필드에 떨어진 아이템 수집
        DropItem     // 필드에 아이템 떨어트림
    }


    public interface IFieldItemManager
    {
        void PerformAction(FieldAction action);
    }
}
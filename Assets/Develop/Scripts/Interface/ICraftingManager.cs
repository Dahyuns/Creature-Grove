namespace CreatureGrove
{
    public enum ItemType   // 임시항목
    {
        WEAPON,            // 무기
        BUILDING_MATERIAL, // 건축 재료
        TOOL,              // 도구
        CONSUMABLE,        // 소모품
        ARMOR,             // 방어구
        ACCESSORY          // 액세서리
    }

    public interface ICraftingManager
    {
        public void createItem(Item item);
    }
}
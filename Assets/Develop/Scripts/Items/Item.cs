namespace CreatureGrove
{
    [System.Serializable]
    public class Item
    {
        public string id; // 예시: "ITEM001", "POTION_A1"
        public string name;
        public string type; 
        public string rarity; // 아이템의 희귀도
        public string effect; // 예시: "Restore 50 HP" (50의 체력을 회복), "Increase Attack Speed"
        public string description; // 설명
        public int attack_power;
        public int level;
        public int amount;
        public string path;
    }

    /* type
        WEAPON,            // 무기
        BUILDING_MATERIAL, // 건축 재료
        TOOL,              // 도구
        CONSUMABLE,        // 소모품
        ARMOR,             // 방어구
        ACCESSORY          // 액세서리
    */

    [System.Serializable]
    public class ItemList
    {
        public Item[] items;
    }
}
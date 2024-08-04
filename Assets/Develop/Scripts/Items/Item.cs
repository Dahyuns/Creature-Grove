namespace CreatureGrove
{
    [System.Serializable]
    public class Item
    {
        public string id; // ����: "ITEM001", "POTION_A1"
        public string name;
        public string type; // ItemType
        public string effect; // ����: "Restore 50 HP" (50�� ü���� ȸ��), "Increase Attack Speed"
        public string rarity; // �������� ��͵�
        public string description; // ����
        public int attack_power;
        public int level;
    }

    [System.Serializable]
    public class ItemList
    {
        public Item[] items;
    }
}
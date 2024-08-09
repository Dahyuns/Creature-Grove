namespace CreatureGrove
{
    // 제작 요청 >> 제작 재료 충분한지 확인 >> 제작 >> 인벤토리에 저장
    public interface ICraftingManager
    {
        public void createItem(Item item);
    }
}
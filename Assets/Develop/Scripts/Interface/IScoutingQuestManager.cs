namespace CreatureGrove
{
    public interface IScoutingQuestManager
    {
        // 1. ��ī�� �õ�
        public void tryScout();

        // 2. ����Ʈ ���� (�ֹ� Ư������ ����Ʈ�� �ٸ�, �ֹ��� ���� ����)
        public void OfferQuest();
    }
}
namespace CreatureGrove
{
    public interface IScoutingQuestManager
    {
        // 1. ��ī�� �õ�
        void tryScout();

        // 2. ����Ʈ ���� (�ֹ� Ư������ ����Ʈ�� �ٸ�, �ֹ��� ���� ����)
        void OfferQuest();
    }
}
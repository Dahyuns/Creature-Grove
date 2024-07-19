namespace CreatureGrove
{
    public interface IScoutingQuestManager
    {
        // 1. 스카웃 시도
        void tryScout();

        // 2. 퀘스트 제공 (주민 특성마다 퀘스트가 다름, 주민은 랜덤 생성)
        void OfferQuest();
    }
}
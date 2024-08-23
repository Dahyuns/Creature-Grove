using UnityEngine;

namespace CreatureGrove
{
    // 몬스터잡으면 일정 확률로 마을원 변경 or 필드 랜덤 소환
    public class Townsfolk : MonoBehaviour, IDamageManager, IScoutingQuestManager
    {
        // [IDamageManager] : 같이 싸움 가능성 있음
        public void Attack(IDamageManager target, float amount)
        {
            target.TakeDamage(amount);
        }

        public void TakeDamage(float amount)
        {

        }

        // [IScoutingQuestManager]
        public void tryScout()
        {

        }

        public void OfferQuest() 
        {

        }
    }
}
using UnityEngine;

namespace CreatureGrove
{
    // 몬스터잡으면 일정 확률로 마을원 변경 or 필드 랜덤 소환
    public class Townsfolk : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager, IScoutingQuestManager
    {
        // [ICraftingManager]
        public void createItem(ItemType type)
        {

        }


        // [IDamageManager] : 같이 싸움 가능성 있음
        public void Attack(GameObject target, float amount)
        {
            Enemy enemy = target.GetComponent<Enemy>();
            enemy.TakeDamage(amount);
        }

        public void TakeDamage(float amount)
        {

        }


        // [IFieldItemManager]
        public void PerformAction(FieldAction action, ItemType itemType)
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
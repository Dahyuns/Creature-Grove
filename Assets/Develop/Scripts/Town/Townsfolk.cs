using UnityEngine;

namespace CreatureGrove
{
    public class Townsfolk : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager, IScoutingQuestManager
    {
        // [ICraftingManager]
        public void createItem(ItemType type)
        {

        }


        // [IDamageManager] : ���� �ο� ���ɼ� ����
        public void Attack(IDamageManager target, float amount)
        {

        }

        public void TakeDamage(float amount)
        {

        }


        // [IFieldItemManager]
        public void PerformAction(FieldAction action)
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
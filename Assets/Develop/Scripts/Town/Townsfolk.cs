using UnityEngine;

namespace CreatureGrove
{
    // ���������� ���� Ȯ���� ������ ���� or �ʵ� ���� ��ȯ
    public class Townsfolk : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager, IScoutingQuestManager
    {
        // [ICraftingManager]
        public void createItem(Item item)
        {

        }


        // [IDamageManager] : ���� �ο� ���ɼ� ����
        public void Attack(IDamageManager target, float amount)
        {
            target.TakeDamage(amount);
        }

        public void TakeDamage(float amount)
        {

        }


        // [IFieldItemManager]
        public void PerformAction(FieldAction action, Item item)
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
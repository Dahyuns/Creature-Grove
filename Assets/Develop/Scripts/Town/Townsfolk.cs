using UnityEngine;

namespace CreatureGrove
{
    // ���������� ���� Ȯ���� ������ ���� or �ʵ� ���� ��ȯ
    public class Townsfolk : MonoBehaviour, ICraftingManager, IDamageManager, IFieldItemManager, IScoutingQuestManager
    {
        // [ICraftingManager]
        public void createItem(ItemType type)
        {

        }


        // [IDamageManager] : ���� �ο� ���ɼ� ����
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
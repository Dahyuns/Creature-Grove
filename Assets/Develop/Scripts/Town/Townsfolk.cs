using UnityEngine;

namespace CreatureGrove
{
    // ���������� ���� Ȯ���� ������ ���� or �ʵ� ���� ��ȯ
    public class Townsfolk : MonoBehaviour, IDamageManager, IScoutingQuestManager
    {
        // [IDamageManager] : ���� �ο� ���ɼ� ����
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
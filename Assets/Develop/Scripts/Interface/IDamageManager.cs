using UnityEngine;

namespace CreatureGrove
{
    public interface IDamageManager
    {
        // ����
        public void Attack(GameObject target, float amount);

        // ����
        public void TakeDamage(float amount);
    }
}
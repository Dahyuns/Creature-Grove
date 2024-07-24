using UnityEngine;

namespace CreatureGrove
{
    public interface IDamageManager
    {
        // 공격
        public void Attack(GameObject target, float amount);

        // 피해
        public void TakeDamage(float amount);
    }
}
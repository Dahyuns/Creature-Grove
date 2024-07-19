namespace CreatureGrove
{
    public interface IDamageManager
    {
        // 공격
        void Attack(IDamageManager target, float amount);

        // 피해
        void TakeDamage(float amount);
    }
}
namespace CreatureGrove
{
    public interface IDamageManager
    {
        // ����
        void Attack(IDamageManager target, float amount);

        // ����
        void TakeDamage(float amount);
    }
}
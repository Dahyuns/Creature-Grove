namespace CreatureGrove
{
    public interface IDamageManager
    {
        // ����
        public void Attack(IDamageManager target, float amount);

        // ����
        public void TakeDamage(float amount);
    }
}
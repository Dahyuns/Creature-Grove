namespace CreatureGrove
{
    public class Dragonfly : Enemy
    {
        // �ִ� ü��
        protected override float Maxhp { get; set; } = 1000f;

        // ���ݷ�
        protected override float atkPower { get; set; } = 1f;

        // ���ݼӵ� (�̻�� - ���� Ÿ�̸ӿ� ����)
        protected override float atkSpeed { get; set; } = 1f;
    }
}
namespace CreatureGrove
{
    public class Dragonfly : Enemy
    {
        // �ִ� ü��
        private float maxHp = 10000f;
        protected override float Maxhp { get { return maxHp; } }

        // ���ݷ�
        private float atkPower = 10;
        public override float AtkPower { get { return atkPower; } }

        // ���ݼӵ� (�̻�� - ���� Ÿ�̸ӿ� ����)
        private float atkSpeed = 1;
        protected override float AtkSpeed { get { return atkSpeed; } }
    }
}
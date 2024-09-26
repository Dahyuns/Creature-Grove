namespace CreatureGrove
{
    public class Dragonfly : Enemy
    {
        // 최대 체력
        private float maxHp = 10000f;
        protected override float Maxhp { get { return maxHp; } }

        // 공격력
        private float atkPower = 10;
        public override float AtkPower { get { return atkPower; } }

        // 공격속도 (미사용 - 공격 타이머와 연동)
        private float atkSpeed = 1;
        protected override float AtkSpeed { get { return atkSpeed; } }
    }
}
namespace CreatureGrove
{
    public class Dragonfly : Enemy
    {
        // 최대 체력
        protected override float Maxhp { get; set; } = 1000f;

        // 공격력
        protected override float atkPower { get; set; } = 1f;

        // 공격속도 (미사용 - 공격 타이머와 연동)
        protected override float atkSpeed { get; set; } = 1f;
    }
}
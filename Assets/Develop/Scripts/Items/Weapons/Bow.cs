using UnityEngine;

namespace CreatureGrove
{
    public class Bow : Weapon
    {
        //private WeaponType type = WeaponType.Bow;
        //public override WeaponType weaponType { get => type; }

        private float atkPower = 100f;
        public override float AtkPower { get => atkPower; }

        private float atkSpeed = 2f;
        public override float AtkSpeed { get => atkSpeed; }

        private float criticalRate = 50f; // 50%추가적용
        public override float CriticalRate { get => criticalRate; }

        private float critHitProb = 30f;
        public override float CritHitProb { get => critHitProb; }

        [SerializeField] private GameObject bowBullet;
        [SerializeField] private GameObject bowBEffect;

        protected override GameObject Bullet() { return bowBullet; }
        protected override GameObject BulletEffect() { return bowBEffect; }

        void ResetGame()
        {
            //초기화
            atkPower = 100f;
            atkSpeed = 2f;
            criticalRate = 50f; // 50%추가적용
            critHitProb = 30f;
        }
    }
}
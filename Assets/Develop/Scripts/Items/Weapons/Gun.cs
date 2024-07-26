using UnityEngine;

namespace CreatureGrove
{
    public class Gun : Weapon
    {
        //private WeaponType type = WeaponType.Gun;
        //public override WeaponType weaponType { get => type; }

        private float atkPower = 200f;
        public override float AtkPower { get => atkPower; }

        private float atkSpeed = 0.5f;
        public override float AtkSpeed { get => atkSpeed; }

        private float criticalRate = 100f; // 100%추가적용
        public override float CriticalRate { get => criticalRate; }

        private float critHitProb = 70f;
        public override float CritHitProb { get => critHitProb; }

        [SerializeField] private GameObject thisBullet;
        [SerializeField] private GameObject thisEffect;

        void ResetGame()
        {
            //초기화
            atkPower = 200f;
            atkSpeed = 0.5f;
            criticalRate = 100f; // 100%추가적용
            critHitProb = 70f;
        }


        protected override void Start()
        {
            base.Start();

            base.bullet = thisBullet;
            base.bEffect = thisEffect;

            ResetGame();
        }
    }
}
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

        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject bEffect;
        [SerializeField] private Transform firePoint;

        protected override GameObject Bullet() { return bullet; }
        protected override GameObject BulletEffect() { return bEffect; }
        protected override Transform FirePoint() { return firePoint; }

        void ResetGame()
        {
            //초기화
            atkPower = 200f;
            atkSpeed = 0.5f;
            criticalRate = 100f; // 100%추가적용
            critHitProb = 70f;
        }


        protected void Start()
        {
            ResetGame();
        }
    }
}
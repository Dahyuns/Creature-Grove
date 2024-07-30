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

        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject bEffect;
        [SerializeField] private Transform firePoint;

        protected override GameObject Bullet() { return bullet; }
        protected override GameObject BulletEffect() { return bEffect; }
        protected override Transform FirePoint() { return firePoint; }

        void ResetGame()
        {
            //초기화
            atkPower = 100f;
            atkSpeed = 2f;
            criticalRate = 50f; // 50%추가적용
            critHitProb = 30f;
        }


        protected void Start()
        {
            ResetGame();
        }
    }
}
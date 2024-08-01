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

        private float criticalRate = 50f; // 50%�߰�����
        public override float CriticalRate { get => criticalRate; }

        private float critHitProb = 30f;
        public override float CritHitProb { get => critHitProb; }

        [SerializeField] private GameObject bowBullet;
        [SerializeField] private GameObject bowBEffect;
        private Transform firePoint;

        protected override GameObject Bullet() { return bowBullet; }
        protected override GameObject BulletEffect() { return bowBEffect; }
        protected override Transform FirePoint() { return firePoint; }

        void Awake()
        {
            firePoint = transform.Find(GameStrings.FirePoint);
        }

        void ResetGame()
        {
            //�ʱ�ȭ
            atkPower = 100f;
            atkSpeed = 2f;
            criticalRate = 50f; // 50%�߰�����
            critHitProb = 30f;
        }
    }
}
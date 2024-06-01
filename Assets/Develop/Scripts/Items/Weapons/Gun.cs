using UnityEngine;

namespace CreatureGrove
{
    public class Gun : Weapon
    {
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
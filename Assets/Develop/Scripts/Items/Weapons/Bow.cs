using UnityEngine;

namespace CreatureGrove
{
    public class Bow : Weapon
    {
        [SerializeField] private GameObject thisBullet;
        [SerializeField] private GameObject thisEffect;

        void ResetGame()
        {
            //초기화
            atkPower = 100f;
            atkSpeed = 2f;
            criticalRate = 50f; // 50%추가적용
            critHitProb = 30f;
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
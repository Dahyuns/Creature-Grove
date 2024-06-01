using UnityEngine;

namespace CreatureGrove
{
    public class Gun : Weapon
    {
        [SerializeField] private GameObject thisBullet;
        [SerializeField] private GameObject thisEffect;

        void ResetGame()
        {
            //�ʱ�ȭ
            atkPower = 200f;
            atkSpeed = 0.5f;
            criticalRate = 100f; // 100%�߰�����
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
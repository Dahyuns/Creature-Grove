using UnityEngine;

namespace CreatureGrove
{
    public class Bow : Weapon
    {
        [SerializeField] private GameObject thisBullet;
        [SerializeField] private GameObject thisEffect;

        void ResetGame()
        {
            //�ʱ�ȭ
            atkPower = 100f;
            atkSpeed = 2f;
            criticalRate = 50f; // 50%�߰�����
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
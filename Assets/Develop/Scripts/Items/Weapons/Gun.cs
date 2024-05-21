using UnityEngine;

namespace CreatureGrove
{
    public class Gun : Weapon
    {
        void Awake()
        {
            ResetGame();
        }

        void ResetGame()
        {
            //�ʱ�ȭ
            atkPower = 200f;
            atkSpeed = 0.5f;
            criticalRate = 100f; // 100%�߰�����
            critHitProb = 70f;
        }

    }
}
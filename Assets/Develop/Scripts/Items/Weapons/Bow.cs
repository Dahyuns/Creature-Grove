using UnityEngine;

namespace CreatureGrove
{
    public class Bow : Weapon
    {
        void Awake()
        {
            ResetGame();
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
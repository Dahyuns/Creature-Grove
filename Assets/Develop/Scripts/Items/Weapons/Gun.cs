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
            //초기화
            atkPower = 200f;
            atkSpeed = 0.5f;
            criticalRate = 100f; // 100%추가적용
            critHitProb = 70f;
        }

    }
}
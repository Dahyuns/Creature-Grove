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
            //초기화
            atkPower = 100f;
            atkSpeed = 2f;
            criticalRate = 50f; // 50%추가적용
            critHitProb = 30f;
        }
    }
}
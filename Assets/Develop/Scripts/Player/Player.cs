using UnityEngine;

namespace CreatureGrove
{
    public class Player : MonoBehaviour
    {
        private static WeaponType weaponType;
        public static WeaponType WeaponType { get { return weaponType; } }
        private float hp;
        private float currentWeight;
        private float stamina;

        // Attack�� Weapon���θ� ����

        public void TakeDamage(float enemyAtk)
        {
            hp -= enemyAtk;
        }
    }
}
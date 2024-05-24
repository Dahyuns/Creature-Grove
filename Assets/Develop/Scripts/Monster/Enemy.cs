using UnityEngine;

namespace CreatureGrove
{
    public class Enemy : MonoBehaviour
    {
        // 체력
        private float hp;

        // 공격력
        private float atkPower;

        // 공격속도
        private float atkSpeed;

        // 참조
        private GameObject thePlayer;

        private void Awake()
        {
            thePlayer = GameObject.Find("Player");
        }

        void Attack()
        {
            //데미지 주기
            Player player = thePlayer.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(atkPower);
            }
        }

        public void TakeDamage(float playerAtk)
        {
            hp -= playerAtk;

            if (hp < 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // 죽는 애니메이션 재생
            // isDead = true;
            // update 첫줄에 리턴?
        }
    }
}
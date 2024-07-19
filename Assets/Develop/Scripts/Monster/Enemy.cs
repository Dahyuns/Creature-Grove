using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyWeaponType
    {
        cudgel, stone // 몽둥이, 돌맹이   ...   창과 방패, 지팡이(마법)
    }

    public class Enemy : MonoBehaviour
    {
        // 체력
        private float Maxhp;
        private float hp;

        private float defenseHPThreshold;

        public bool IsMaxHp
        {
            get { return hp >= Maxhp; }
        }

        // 공격력
        private float atkPower;

        // 공격속도
        private float atkSpeed;

        // 참조
        private GameObject thePlayer;

        private void Awake()
        {
            thePlayer = GameObject.Find("Player");
            hp = Maxhp;
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
                hp = 0;
                Die();
            }
        }

        private void Die()
        {
            // 죽는 애니메이션 재생
            // isDead = true;
            // update 첫줄에 리턴?
        }

        public void Heal()
        {
            hp += 10;
            if (hp > Maxhp)
            {
                hp = Maxhp;
            }
        }
    }
}
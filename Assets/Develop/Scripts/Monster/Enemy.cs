using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyWeaponType
    {
        cudgel, stone // ������, ������   ...   â�� ����, ������(����)
    }

    public class Enemy : MonoBehaviour
    {
        // ü��
        private float Maxhp;
        private float hp;

        private float defenseHPThreshold;

        public bool IsMaxHp
        {
            get { return hp >= Maxhp; }
        }

        // ���ݷ�
        private float atkPower;

        // ���ݼӵ�
        private float atkSpeed;

        // ����
        private GameObject thePlayer;

        private void Awake()
        {
            thePlayer = GameObject.Find("Player");
            hp = Maxhp;
        }

        void Attack()
        {
            //������ �ֱ�
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
            // �״� �ִϸ��̼� ���
            // isDead = true;
            // update ù�ٿ� ����?
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
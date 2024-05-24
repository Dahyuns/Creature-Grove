using UnityEngine;

namespace CreatureGrove
{
    public class Enemy : MonoBehaviour
    {
        // ü��
        private float hp;

        // ���ݷ�
        private float atkPower;

        // ���ݼӵ�
        private float atkSpeed;

        // ����
        private GameObject thePlayer;

        private void Awake()
        {
            thePlayer = GameObject.Find("Player");
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
                Die();
            }
        }

        private void Die()
        {
            // �״� �ִϸ��̼� ���
            // isDead = true;
            // update ù�ٿ� ����?
        }
    }
}
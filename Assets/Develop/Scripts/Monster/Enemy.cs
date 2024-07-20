using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyWeaponType
    {
        cudgel, stone // ������, ������   ...   â�� ����, ������(����)
    }

    public class Enemy : MonoBehaviour, IDamageManager, IFieldItemManager
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

        #region
        void sAttack()
        {
            //������ �ֱ�
            Player player = thePlayer.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(atkPower);
            }
        }

        public void sTakeDamage(float playerAtk)
        {
            hp -= playerAtk;

            if (hp < 0)
            {
                hp = 0;
                sDie();
            }
        }

        private void sDie()
        {
            // �״� �ִϸ��̼� ���
            // isDead = true;
            // update ù�ٿ� ����?
        }

        public void sHeal()
        {
            hp += 10;
            if (hp > Maxhp)
            {
                hp = Maxhp;
            }
        }
        #endregion


        // [IDamageManager]
        public void Attack(IDamageManager target, float amount)
        {

        }

        public void TakeDamage(float amount)
        {

        }


        // [IFieldItemManager]
        public void PerformAction(FieldAction action)
        {

        }
    }
}
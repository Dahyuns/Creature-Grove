using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyWeaponType
    {
        cudgel, stone // ������, ������   ...   â�� ����, ������(����)
    }

    public class FieldEnemy : MonoBehaviour, IDamageManager
    {
        // ü��
        private float Maxhp = 1000f;
        private float hp;
        public float HP
        {
            get => hp;
        }

        private float healGauge = 2f;

        public bool IsMaxHp
        {
            get { return hp >= Maxhp; }
        }

        // ����
        private GameObject thePlayer;

        private void Awake()
        {
            thePlayer = GameObject.Find("Player");
            hp = Maxhp;
        }

        #region
        private void Die()
        {
            Debug.Log("enemy Died");

            // �״� �ִϸ��̼� ���

            // update ù�ٿ� ����? �Ǵ� ��Ȱ��ȭ(�Ʒ�)
            gameObject.SetActive(false);
        }

        public void Heal()
        {
            hp += healGauge;

            if (hp > Maxhp)
            {
                hp = Maxhp;
            }
        }
        #endregion

        #region [IDamageManager] 
        // ���ݷ�
        private float atkPower;
        public float AtkPower { get { return atkPower; } }

        // ���ݼӵ� (�̻�� - ���� Ÿ�̸ӿ� ����)
        private float atkSpeed;

        public void Attack(IDamageManager target, float amount)
        {
            target.TakeDamage(amount);
        }

        public void TakeDamage(float amount)
        {
            GetComponent<FieldEnemyBehavior>().SendMessage("DamageTimer", SendMessageOptions.RequireReceiver);
            if (hp - amount > 0)
            {

                hp -= amount;
            }
            else
            {
                hp = 0;

                // ����
                Die();
            }
            Debug.Log("enemy Hp : " + hp);
        }
        #endregion
    }
}
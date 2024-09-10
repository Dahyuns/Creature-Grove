using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyWeaponType
    {
        cudgel, stone // ������, ������   ...   â�� ����, ������(����)
    }

    public class Enemy : MonoBehaviour, IDamageManager
    {
        // ü��
        private float Maxhp = 1000f;
        private float hp;
        public float HP
        {
            get => hp;
        }

        private float defenseHPThreshold;

        public bool IsMaxHp
        {
            get { return hp >= Maxhp; }
        }

        // ���ݷ�
        private float atkPower;
        public float AtkPower { get { return atkPower; } }

        // ���ݼӵ�
        private float atkSpeed;

        // ����
        private GameObject thePlayer;

        private void Awake()
        {
            thePlayer = GameObject.Find("Player");
            hp = Maxhp;
        }

        void Update()
        {
        }

        #region
        private void Die()
        {
            // �״� �ִϸ��̼� ���

            // update ù�ٿ� ����? �Ǵ� ��Ȱ��ȭ(�Ʒ�)
            gameObject.SetActive(false);
        }

        public void sHeal() // ��ų
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
            target.TakeDamage(amount);
        }

        public void TakeDamage(float amount)
        {
            Debug.Log(hp);
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
        }
    }
}
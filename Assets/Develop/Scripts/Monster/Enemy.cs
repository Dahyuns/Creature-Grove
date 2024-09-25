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
        protected virtual float Maxhp { get; } // ���(�ִ� ü��)
        protected float currentHp { get; set; }
        public float HP { get => currentHp; }

        // Ǯ���ΰ�?
        public bool IsMaxHp { get { return currentHp >= Maxhp; } }

        // ���� �ð��� �� ������
        protected float healGauge { get => Maxhp / 500; }

        // Death
        protected bool isDead = false;
        public bool IsDead { get { return isDead; } }

        // ���ݷ�
        public virtual float AtkPower { get; } // ���

        // ���ݼӵ� (�̻�� - ���� Ÿ�̸ӿ� ����)
        protected virtual float AtkSpeed { get; } // ���

        // ����
        protected GameObject thePlayer;
        protected Animator animator;

        // animation strings
        protected string DamagedTrigger = "Damaged";
        protected string DieTrigger = "Die";

        protected void Awake()
        {
            // ����
            thePlayer = GameObject.Find("Player");
            animator = GetComponent<Animator>();

            currentHp = Maxhp;
        }

        public void Heal()
        {
            currentHp += healGauge;

            if (currentHp > Maxhp)
            {
                currentHp = Maxhp;
            }
        }

        public void Die()
        {
            Debug.Log("enemy Died");

            // �״� �ִϸ��̼� ���
            animator.SetTrigger(DieTrigger);
            // ������ ȿ�� �߰�?

            // [   ] 1. ����     // Destroy(gameObject, destoryDelay);
            // [   ] 2. ��Ȱ��ȭ(�Ʒ�)
            // [ V ] 3. �ִϸ��̼ǿ��� �����Ͽ� under�� ��ġ
        }

        #region [IDamageManager] 
        public void Attack(IDamageManager target, float amount)
        {
            target.TakeDamage(amount);
        }

        public void TakeDamage(float amount)
        {
            GetComponent<FieldEnemyBehavior>().SendMessage("DamageTimer", SendMessageOptions.RequireReceiver);
            if (currentHp - amount > 0)
            {
                currentHp -= amount;
                animator.SetTrigger(DamagedTrigger);
            }
            else
            {
                currentHp = 0;

                // ����
                Die();
                isDead = true;
            }
            Debug.Log("enemy Hp : " + currentHp);
        }
        #endregion
    }
}
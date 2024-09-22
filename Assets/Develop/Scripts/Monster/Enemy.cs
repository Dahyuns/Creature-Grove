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
        protected virtual float Maxhp { get; set; } = 1000f;
        protected float currentHp { get; set; }
        public float HP { get => currentHp; }

        public bool IsMaxHp { get { return currentHp >= Maxhp; } }

        protected float healGauge { get => Maxhp / 500; }

        protected bool isDeath = false;
        public bool IsDeath { get { return isDeath; } }

        // ���ݷ�
        protected virtual float atkPower { get; set; } = 1f;
        public float AtkPower { get { return atkPower; } }

        // ���ݼӵ� (�̻�� - ���� Ÿ�̸ӿ� ����)
        protected virtual float atkSpeed { get; set; } = 1f;

        // ����
        protected GameObject thePlayer;

        // animation strings
        protected string DamagedTrigger = "Damaged";
        protected string DieTrigger = "Die";

        protected void Awake()
        {
            // ����
            thePlayer = GameObject.Find("Player");

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
            }
            else
            {
                currentHp = 0;

                // ����
                Die();
                isDeath = true;
            }
            Debug.Log("enemy Hp : " + currentHp);
        }
        #endregion
    }
}
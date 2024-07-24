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
        public void Attack(GameObject target, float amount)
        {
            Player player = target.GetComponent<Player>();
            player.TakeDamage(amount);
        }

        public void TakeDamage(float amount)
        {
            if (hp - amount >= 0)
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

        // [IFieldItemManager]
        public void PerformAction(FieldAction action, ItemType itemType)
        {

        }
    }
}
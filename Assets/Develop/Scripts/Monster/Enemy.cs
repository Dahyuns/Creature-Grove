using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyWeaponType
    {
        cudgel, stone // 몽둥이, 돌맹이   ...   창과 방패, 지팡이(마법)
    }

    public class Enemy : MonoBehaviour, IDamageManager
    {
        // 체력
        protected virtual float Maxhp { get; } // 상속(최대 체력)
        protected float currentHp { get; set; }
        public float HP { get => currentHp; }

        // 풀피인가?
        public bool IsMaxHp { get { return currentHp >= Maxhp; } }

        // 단위 시간당 힐 게이지
        protected float healGauge { get => Maxhp / 500; }

        // Death
        protected bool isDead = false;
        public bool IsDead { get { return isDead; } }

        // 공격력
        public virtual float AtkPower { get; } // 상속

        // 공격속도 (미사용 - 공격 타이머와 연동)
        protected virtual float AtkSpeed { get; } // 상속

        // 참조
        protected GameObject thePlayer;
        protected Animator animator;

        // animation strings
        protected string DamagedTrigger = "Damaged";
        protected string DieTrigger = "Die";

        protected void Awake()
        {
            // 참조
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

            // 죽는 애니메이션 재생
            animator.SetTrigger(DieTrigger);
            // 디졸브 효과 추가?

            // [   ] 1. 삭제     // Destroy(gameObject, destoryDelay);
            // [   ] 2. 비활성화(아래)
            // [ V ] 3. 애니메이션에서 설정하여 under에 위치
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

                // 죽음
                Die();
                isDead = true;
            }
            Debug.Log("enemy Hp : " + currentHp);
        }
        #endregion
    }
}
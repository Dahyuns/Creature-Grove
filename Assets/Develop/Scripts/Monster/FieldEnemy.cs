using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyWeaponType
    {
        cudgel, stone // 몽둥이, 돌맹이   ...   창과 방패, 지팡이(마법)
    }

    public class FieldEnemy : MonoBehaviour, IDamageManager
    {
        // 체력
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

        // 참조
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

            // 죽는 애니메이션 재생

            // update 첫줄에 리턴? 또는 비활성화(아래)
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
        // 공격력
        private float atkPower;
        public float AtkPower { get { return atkPower; } }

        // 공격속도 (미사용 - 공격 타이머와 연동)
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

                // 죽음
                Die();
            }
            Debug.Log("enemy Hp : " + hp);
        }
        #endregion
    }
}
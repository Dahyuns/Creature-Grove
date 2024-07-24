using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyWeaponType
    {
        cudgel, stone // 몽둥이, 돌맹이   ...   창과 방패, 지팡이(마법)
    }

    public class Enemy : MonoBehaviour, IDamageManager, IFieldItemManager
    {
        // 체력
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

        // 공격력
        private float atkPower;

        // 공격속도
        private float atkSpeed;

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
            // 죽는 애니메이션 재생

            // update 첫줄에 리턴? 또는 비활성화(아래)
            gameObject.SetActive(false);
        }

        public void sHeal() // 스킬
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

                // 죽음
                Die();
            }
        }

        // [IFieldItemManager]
        public void PerformAction(FieldAction action, ItemType itemType)
        {

        }
    }
}
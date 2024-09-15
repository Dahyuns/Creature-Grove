using UnityEngine;
using System.Collections;

namespace CreatureGrove
{
    public class BossEnemyBehavior : EnemyBehavior
    {
        // [방어 쿨타임]
        protected bool isDefend = false;
        protected float defendTimer = 3f;

        // 방어 [보스몹 전용]
        protected IEnumerator defendCooldown(float duration)
        {
            isDefend = true;
            yield return new WaitForSeconds(duration);
            isDefend = false;
        }

        protected override void Update()
        {
            base.Update();

            switch (currentState)
            {
                // [방어]
                case EnemyState.Defend:

                    // 방어 쿨타임이 아니라면
                    if (isDefend == false)
                    {
                        StartCoroutine(defendCooldown(defendTimer));
                        // 방어 태새 갖추기, 방어중엔 true
                        // 방어력 추가 >> Enemy.takeDamage에서 적용됨
                    }

                    break;
            }
        }
    }
}
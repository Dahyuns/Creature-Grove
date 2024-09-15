using UnityEngine;
using System.Collections;

namespace CreatureGrove
{
    public class BossEnemyBehavior : EnemyBehavior
    {
        // [��� ��Ÿ��]
        protected bool isDefend = false;
        protected float defendTimer = 3f;

        // ��� [������ ����]
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
                // [���]
                case EnemyState.Defend:

                    // ��� ��Ÿ���� �ƴ϶��
                    if (isDefend == false)
                    {
                        StartCoroutine(defendCooldown(defendTimer));
                        // ��� �»� ���߱�, ����߿� true
                        // ���� �߰� >> Enemy.takeDamage���� �����
                    }

                    break;
            }
        }
    }
}
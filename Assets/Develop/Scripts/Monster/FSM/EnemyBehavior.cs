using System.Collections;
using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyState
    {
        // field용
        Idle, Patroll, Chase, Attack, Run,

        // wave용
        Search,

        // boss용
        Defend
    }

    public class EnemyBehavior : MonoBehaviour
    {
        // 참조
        protected GameObject theTarget;
        protected Enemy theEnemy;

        // [현재 (플레이어까지의) 방향 벡터와 거리]
        protected float distanceToTarget { get { return (theTarget.transform.position - this.transform.position).magnitude; } }

        // [기준 거리]
        protected float patrolStartDistance = 20f; // 탐색
        protected float chaseStartDistance = 20f;  // 추격
        protected float attackStartDistance = 20f; // 공격

        // 최대 체력의 2/3,  1/3
        protected float MidHealthThreshold;
        protected float LowHealthThreshold;

        // 이거 enemy에서 가져오는게 나을지도?
        protected float walkSpeed = 10f;

        #region 쿨타임용 
        protected bool isAttack = false;
        protected bool isHeal = false;
        protected bool isDamaged = false;

        protected float atkTimer = 1.5f;
        protected float healTimer = 3f;
        protected float damagedTimer = 8f;
        #endregion

        // [상태]
        protected EnemyState currentState;
        protected EnemyState beforeState;

        // 여기 구현ㄱㄱ
        #region 실제사용함수
        protected virtual void eIdle()
        {
            // 가만히 있기
        }

        protected virtual void ePatroll()
        {
            // 탐색 (순찰)
            // 경로따라서 순찰
        }

        protected virtual void eChase()
        {
            // 목표를 향해 걷기
            WalkTo(theTarget.transform);
        }

        protected virtual void eRun()
        {
            // 서있던 방향 반대쪽으로 일자 이동
        }

        protected virtual void eHeal()
        {
            theEnemy.Heal();
        }

        protected void eSearch()
        {
            // 가장 가까운 마을 오브젝트 검색
        }

        protected void WalkTo(Transform tr)
        {
            this.transform.Translate(tr.position.normalized * walkSpeed * Time.deltaTime);
        }
        #endregion

        protected virtual void Awake()
        {
            // 참조
            theTarget = GameObject.Find("Player");
            theEnemy = GetComponent<FieldEnemy>();
        }

        protected virtual void Update()
        {
            GlobalLogicHeal();

            switch (currentState)
            {
                // [공격]
                case EnemyState.Attack:

                    // 공격 쿨타임이 아니라면
                    if (isAttack == false)
                    {
                        // 공격 타이머 ON (isHeal == true)
                        StartCoroutine(AttackCooldown(atkTimer));

                        // 한번 공격
                        theEnemy.Attack(theTarget.GetComponent<IDamageManager>(), theEnemy.AtkPower);
                    }
                    else
                    {
                        // 가만히 있을때 애니메이션... 추가 구현
                    }

                    // 플레이어가 공격 범위 밖으로 나갔다면 "추적"
                    if (distanceToTarget > attackStartDistance)
                    {
                        SetState(EnemyState.Chase);
                    }
                    break;
            }
        }

        protected void SetState(EnemyState state)
        {
            beforeState = currentState;
            currentState = state;
        }

        /// <summary>
        ///  힐 !!
        /// [데미지를 안받고,힐 쿨타임, Max피가 아닐때]
        /// </summary>
        protected void GlobalLogicHeal()
        {
            // 힐 쿨이 안돌았다면
            if (isHeal == false)
            {
                // 힐 타이머 (동안 isHeal == true)
                StartCoroutine(healCooldown(healTimer));

                // 최대 체력까지 힐하기
                if (theEnemy.IsMaxHp == false)
                {
                    // 데미지 안받고 있을때
                    if (isDamaged == false)
                    {
                        eHeal();
                    }
                }
            }
        }

        #region 쿨타임
        // 공격
        protected IEnumerator AttackCooldown(float duration)
        {
            isAttack = true;
            yield return new WaitForSeconds(duration);
            isAttack = false;
        }

        // 힐
        protected IEnumerator healCooldown(float duration)
        {
            isHeal = true;
            yield return new WaitForSeconds(duration);
            isHeal = false;
        }

        // 데미지받고난 시간 계산 (8초)
        public void DamageTimer()
        {
            StartCoroutine(demagedCooldown(damagedTimer));
        }

        protected IEnumerator demagedCooldown(float duration)
        {
            isDamaged = true;
            yield return new WaitForSeconds(duration);
            isDamaged = false;

        }
        #endregion
    }
}
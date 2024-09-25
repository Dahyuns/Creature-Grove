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
    
    //생성 만들어야 fsm 작동되는지 볼수있음!
    public class EnemyBehavior : MonoBehaviour
    {
        // 참조
        protected Animator animator;
        protected GameObject theTarget;

        // [현재 (타겟까지의) 방향 벡터와 거리]
        protected float distanceToTarget { get { return (theTarget.transform.position - this.transform.position).magnitude; } }

        // [Run]
        protected bool isRun = false;
        protected Vector3 oppositeDir = Vector3.zero;
        protected float walkSpeed = 10f;

        // [기준 거리]
        protected float chaseStartDistance = 20f;  // 추격
        protected float attackStartDistance = 20f; // 공격

        // 최대 체력의 2/3,  1/3
        protected float MidHealthThreshold;
        protected float LowHealthThreshold;

        // animation strings
        protected string AttackTrigger = "Attack";
        protected string SpeedLevel = "Speed";

        #region [FSM]
        protected EnemyState currentState;
        protected EnemyState beforeState;

        // 상태 변경
        protected void SetState(EnemyState newState)
        {
            // 상태 변경 체크
            if (currentState == newState)
                return;

            // 상태 변경
            beforeState = currentState;
            currentState = newState;

            // 상태 변경에 따른 애니메이션 설정
            // 공격, 데미지받음, 죽음 빼고 다 IDLE!
            //animator.SetInteger(enemyState, (int)currentState);
        }
        #endregion

        #region 쿨타임
        protected bool isAttack = false;
        protected bool isHeal = false;
        protected bool isDamaged = false;

        protected float atkTimer = 1.5f;
        protected float healTimer = 3f;
        protected float damagedTimer = 8f;

        // 공격
        protected IEnumerator AttackCooldown()
        {
            isAttack = true;
            yield return new WaitForSeconds(atkTimer);
            isAttack = false;
        }

        // 힐
        protected IEnumerator healCooldown()
        {
            isHeal = true;
            yield return new WaitForSeconds(healTimer);
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

        // 목표를 향해 걷기
        protected virtual void eChase()
        {
            // 이 오브젝트 높이에 맞춤
            Vector3 tg = new Vector3(theTarget.transform.position.x, this.transform.position.y, theTarget.transform.position.z);

            // 타겟까지의 벡터
            Vector3 dir = tg - this.transform.position;

            // 이동
            transform.Translate(dir.normalized * Time.deltaTime * walkSpeed, Space.World);

            // 회전
            transform.LookAt(tg);
        }

        // 다른 방향으로 도망치기
        protected virtual void eRun()
        {
            // 반대 방향으로 이동할 때
            transform.Translate(oppositeDir.normalized * Time.deltaTime * walkSpeed, Space.World);
        }

        // 힐 : GlobalState
        #region  힐 [데미지를 안받고,쿨타임, MaxHP가 아닐때]
        protected void GlobalLogicHeal()
        {
            // 힐 쿨이 안돌았다면
            if (isHeal == false)
            {
                // 힐 타이머 (동안 isHeal == true)
                StartCoroutine(healCooldown());

                // 최대 체력까지 힐하기
                if (theEnemy.IsMaxHp == false)
                {
                    // 데미지 안받고 있을때
                    if (isDamaged == false)
                    {
                        theEnemy.Heal();
                    }
                }
            }
        }
        #endregion

        protected Enemy theEnemy;

        protected virtual void Awake()
        {
            // 참조
            theTarget = GameObject.Find("Player");
            theEnemy = GetComponent<Enemy>();
            animator = GetComponent<Animator>();
        }

        protected virtual void Update()
        {
            if (theEnemy.IsDead)
                return;

            // [GlobalState]
            GlobalLogicHeal();

            switch (currentState)
            {
                // [공격]
                case EnemyState.Attack:

                    // 공격 쿨타임이 아니라면
                    if (isAttack == false)
                    {
                        // 공격 타이머 ON (isHeal == true)
                        StartCoroutine(AttackCooldown());

                        // 한번 공격
                        theEnemy.Attack(theTarget.GetComponent<IDamageManager>(), theEnemy.AtkPower);

                        // 애니메이션
                        animator.SetTrigger(AttackTrigger);
                    }

                    // 플레이어가 공격 범위 밖으로 나갔다면 "추적"
                    if (distanceToTarget > attackStartDistance)
                    {
                        SetState(EnemyState.Chase);
                    }
                    break;
            }
        }
    }
}
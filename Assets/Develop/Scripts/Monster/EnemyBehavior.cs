using System.Collections;
using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyState
    {
        Idle, Patroll, Chase, Attack, Defend, Run, Heal
       // 몬스터Wave구현 (Gathering, Attacking town...) 따로 하나 더 만들지 고민중, 참조를 마을로? 아님 damageable 객체들로??
    }

    // 적의 구체적인 행동 패턴을 정의 ( AI, 움직임, 플레이어를 추적하는 방법 )
    public class EnemyBehavior : MonoBehaviour
    {
        // 참조
        private Player thePlayer;
        private Enemy theEnemy;

        // [상태]
        private EnemyState currentState;
        private EnemyState beforeState;

        // [기준 거리]
        private float patrolStartDistance = 20f; // 탐색
        private float chaseStartDistance = 20f;  // 추격
        private float attackStartDistance = 20f; // 공격

        // [현재 (플레이어까지의) 방향 벡터와 거리]
        private Vector3 DirToPlayer { get { return thePlayer.gameObject.transform.position - this.transform.position; } }
        private float distanceToPlayer { get { return DirToPlayer.magnitude; } }

        // 최대 체력의 2/3,  1/3
        private float MidHealthThreshold;
        private float LowHealthThreshold;


        private bool isAttack = false;
        private bool isHeal = false;
        private bool isDamaged = false;
        //private bool isDefend = false;   //[방어 - 보스용]

        private float atkTimer = 1.5f;
        private float healTimer = 3f;
        private float damagedTimer = 8f;
        //private float defendTimer = 3f;   //[방어 - 보스용]

        private void SetState(EnemyState state)
        {
            beforeState = currentState;
            currentState = state;
        }

        // 여기 구현ㄱㄱ
        #region 실제사용함수
        private void eIdle()
        {
            // 가만히 있기
        }

        private void ePatroll()
        {
            // 탐색 (순찰)
            // 경로따라서 순찰
        }

        private void eChase()
        {
            // 목표를 향해 걷기
        }

        private void eRun()
        {
            // 서있던 방향 반대쪽으로 일자 이동
        }

        private void eHeal()
        {
            theEnemy.Heal();
        }
        #endregion

        /// <summary>
        /// 데미지를 안받고 있을때만 "힐" 상태로 전환해줍니다!
        /// </summary>
        private void callHeal()
        {
            // 데미지 안받고 있을때
            if (isDamaged == false)
            {
                SetState(EnemyState.Heal);
            }
        }

        #region 쿨타임
        // 공격
        private IEnumerator AttackCooldown(float duration)
        {
            isAttack = true;
            yield return new WaitForSeconds(duration);
            isAttack = false;
        }

        // 힐
        private IEnumerator healCooldown(float duration)
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

        private IEnumerator demagedCooldown(float duration)
        {
            isDamaged = true;
            yield return new WaitForSeconds(duration);
            isDamaged = false;

        }

        // 방어 [보스몹 전용]
        /*
        private IEnumerator defendCooldown(float duration)
        {
            isDefend = true;
            yield return new WaitForSeconds(duration);
            isDefend = false;
        }
        */
        #endregion

        private void Awake()
        {
            // 참조
            thePlayer = GameObject.Find("Player").GetComponent<Player>();
            theEnemy = GetComponent<Enemy>();

            // 현재상태 "대기"로 설정
            currentState = EnemyState.Idle;
        }

        private void Update()
        {
            //(플레이어와의 거리가) 
            switch (currentState)
            {
                // [대기]
                case EnemyState.Idle:

                    // 대기 상태
                    eIdle();

                    // 최대 체력까지 힐하기
                    if (theEnemy.IsMaxHp == false)
                    {
                        callHeal();
                    }

                    // 탐색거리보다 가까워졌다  "검색"
                    if (distanceToPlayer <= patrolStartDistance)
                    {
                        SetState(EnemyState.Patroll);
                    }
                    /*
                    // 검색거리보다 멀때 "힐"
                    else
                    {
                        // 만약 피가 깎였다면
                        if (GetComponent<Enemy>().IsMaxHp == false)
                        {
                            currentState = EnemyState.Heal;
                        }
                    }
                    */
                    break;


                // [탐색(순찰)]
                case EnemyState.Patroll:

                    // 탐색 (순찰)
                    ePatroll();

                    // 최대 체력까지 힐하기
                    if (theEnemy.IsMaxHp == false)
                    {
                        callHeal();
                    }

                    // 추격거리보다 가까워졌다  "추격"
                    if (distanceToPlayer <= chaseStartDistance)
                    {
                        SetState(EnemyState.Chase);
                    }

                    // 추격거리보다 멀다 "탐색(현재상태)"
                    else
                    {
                        // 탐색거리보다 멀어졌다  "대기"
                        if (distanceToPlayer > patrolStartDistance)
                        {
                            SetState(EnemyState.Idle);
                        }
                    }

                    break;


                // [추격]
                case EnemyState.Chase:

                    // 목표를 향해 걷기
                    eChase();

                    // 최대 체력까지 힐하기
                    if (theEnemy.IsMaxHp == false)
                    {
                        callHeal();
                    }

                    // 체력 : 1/3 보다 많으면 "공격"
                    if (theEnemy.HP >= LowHealthThreshold)
                    {
                        // 공격거리보다 가까워졌다면 "공격"
                        if (distanceToPlayer <= attackStartDistance)
                        {
                            SetState(EnemyState.Attack);
                        }
                        // 공격거리보다 멀다 "추격(현재상태)"
                        else
                        {
                            // 추격거리보다 멀어졌다  "탐색"
                            if (distanceToPlayer > chaseStartDistance)
                            {
                                SetState(EnemyState.Patroll);
                            }
                        }
                    }
                    // 체력 : 1/3 보다 적으면 "도망"
                    else
                    {
                        SetState(EnemyState.Run);
                    }

                    break;


                // [공격]
                case EnemyState.Attack:

                    // 공격 쿨타임이 아니라면
                    if(isAttack == false)
                    {
                        // 공격 타이머 ON (isHeal == true)
                        StartCoroutine(AttackCooldown(atkTimer));

                        // 한번 공격
                        theEnemy.Attack(thePlayer, theEnemy.AtkPower);
                    }

                    // 플레이어가 공격 범위 밖으로 나갔다면 "추적"
                    if (distanceToPlayer > attackStartDistance)
                    {
                        SetState(EnemyState.Chase);
                    }
                    break;


                // [도망 - 일반몹 전용]
                case EnemyState.Run:

                    // 추격 거리보다 작다면 계속 "도망"
                    if (distanceToPlayer < chaseStartDistance)
                    {
                        // 도망가기(일단 보는 방향 반대방향으로 일자 도망, 좌우는 추가 구현)
                        eRun();

                        // (체력이)
                        // 2/3보다 적다면 힐 (도망 가면서 힐되는 중)
                        if (theEnemy.HP < MidHealthThreshold)
                        {
                            callHeal();
                        }
                        // 2/3보다 많다면 다시 추격하기
                        else
                        {
                            SetState(EnemyState.Chase);
                        }
                    }
                    // 추격 거리보다 멀어졌다면 "탐색(순찰)"
                    else
                    {
                        SetState(EnemyState.Patroll);
                    }

                    break;


                // [치유]
                case EnemyState.Heal:

                    // 힐 쿨이 안돌았다면
                    if (isHeal == false)
                    {
                        // 힐 타이머 (동안 isHeal == true)
                        StartCoroutine(healCooldown(healTimer));

                        // 힐 한번
                        eHeal();

                    }

                    // 전 상태로 
                    SetState(beforeState);

                    break;


                // [방어 - 보스 전용] 아직 미구현
                /*
                case EnemyState.Defend:

                    // 방어 쿨타임이 아니라면
                    if (isDefend == false)
                    {
                        // 방어 태새 갖추기, 방어중엔 true
                        // 방어력 추가 >> Enemy.takeDamage에서 적용됨
                    }

                    // 데미지 안받고 있으면 힐하기
                    if (isDamaged == false)
                    {
                        SetState(EnemyState.Heal);
                    }      

                    break;
                */


                default:
                    break;
            }
        }

    }
}
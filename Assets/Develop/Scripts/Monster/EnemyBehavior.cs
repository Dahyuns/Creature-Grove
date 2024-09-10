using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyState
    {
        Idle, Patroll, Chase, Attack, Defend, Run, Heal
    }

    // 적의 구체적인 행동 패턴을 정의 ( AI, 움직임, 플레이어를 추적하는 방법 )
    public class EnemyBehavior : MonoBehaviour
    {
        // 탐색거리
        private float patrolStartDistance = 20f;
        // 추격거리
        private float chaseStartDistance = 20f;
        // 공격거리
        private float attackStartDistance = 20f;

        // 최대 체력의 2/3
        private float MidHealthThreshold;
        // 최대 체력의 1/3
        private float LowHealthThreshold;

        private Vector3 DirToPlayer { get { return thePlayer.gameObject.transform.position - this.transform.position; } }
        private float distanceToPlayer { get { return DirToPlayer.magnitude;  } }

        // 플레이어의 상태
        private EnemyState currentState;
        private EnemyState beforeState;

        // 참조
        private Player thePlayer;
        private Enemy theEnemy;

        private void Awake()
        {
            thePlayer = GameObject.Find("Player").GetComponent<Player>();
            theEnemy = GetComponent<Enemy>();
            currentState = EnemyState.Idle;
        }
        
        private void SetState(EnemyState state)
        {
            beforeState = currentState;
            currentState = state;
        }

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

        //(플레이어와의 거리가) 
        private void Update()
        {
            switch (currentState)
            {
                // [대기]
                case EnemyState.Idle:

                    // 대기 상태
                    eIdle();

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


                // [탐색]
                case EnemyState.Patroll:

                    // 탐색 (순찰)
                    ePatroll();

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

                    // 체력 > 2/3 "공격"
                    if (theEnemy.HP >= MidHealthThreshold)
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

                    // 2/3 > 체력 > 1/3 "방어 + 힐"
                    else if (theEnemy.HP >= LowHealthThreshold)
                    {
                        SetState(EnemyState.Defend);
                    }

                    // 1/3 > 체력  "도망 + 힐"
                    else
                    {
                        SetState(EnemyState.Run);
                    }

                    break;


                // [공격]
                case EnemyState.Attack:

                    // 한번 공격
                    theEnemy.Attack(thePlayer, theEnemy.AtkPower);

                    // 플레이어가 공격 범위 밖으로 나갔다면 "추적"
                    if (distanceToPlayer > attackStartDistance)
                    {
                        SetState(EnemyState.Chase);
                    }
                    break;


                // [도망] 일반몹 - 체력 일정수준 이하
                case EnemyState.Run:

                    break;


                // [방어] 보스몹 - 체력 일정수준 이하
                case EnemyState.Defend:

                    // 방어 태새 갖추기

                    // 방어력 추가 >> Enemy.takeDamage에서 적용됨

                    // 데미지 안받고 있으면 힐하기
                    SetState(EnemyState.Heal);

                    break;


                // [치유]
                case EnemyState.Heal:

                    // 힐 한번
                    theEnemy.sHeal();

                    // 전 상태로 
                    SetState(beforeState);
                    break; 


                default:
                    break;
            }
        }

    }
}
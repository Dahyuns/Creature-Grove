using UnityEngine;

namespace CreatureGrove
{
    public class FieldEnemyBehavior : EnemyBehavior
    {
        // 탐색 기준 거리
        protected float patrolStartDistance = 20f;

        // 탐색 (순찰)
        protected virtual void ePatroll()
        {
            // 목표지점으로 이동
        }

        protected override void Awake()
        {
            base.Awake();

            // 현재상태 "대기"로 설정
            currentState = EnemyState.Idle;
        }

        protected override void Update()
        {
            base.Update();

            // Idle - Patroll - Chase - Run - (Attack)
            switch (currentState)
            {
                // [대기]
                case EnemyState.Idle:

                    // 가만히 있는 애니메이션 설정
                    animator.SetInteger(SpeedLevel, 0); // Idle

                    //(플레이어와의 거리가) 
                    // 탐색거리보다 가까워졌다  "검색"
                    if (distanceToTarget <= patrolStartDistance)
                    {
                        SetState(EnemyState.Patroll);
                    }

                    break;

                // 이동 도중 멈추기
                // agent.isStopped = true;  // 멈춤
                // agent.isStopped = false; // 다시 이동 시작

                // [탐색(순찰)]
                case EnemyState.Patroll:

                    // 탐색 (순찰)
                    ePatroll();

                    // 걷는 애니메이션 설정
                    animator.SetInteger(SpeedLevel, 1); // 1 : 걷기

                    // 추격거리보다 가까워졌다  "추격"
                    if (distanceToTarget <= chaseStartDistance)
                    {
                        SetState(EnemyState.Chase);
                    }

                    // 추격거리보다 멀다 "탐색(현재상태)"
                    else
                    {
                        // 탐색거리보다 멀어졌다  "대기"
                        if (distanceToTarget > patrolStartDistance)
                        {
                            SetState(EnemyState.Idle);
                        }
                    }
                    break;


                // [추격]
                case EnemyState.Chase:

                    // 목표를 향해 뛰기
                    eChase();

                    // 뛰는 애니메이션 설정
                    animator.SetInteger(SpeedLevel, 2); // 뛰기

                    // 체력 : 1/3 보다 많으면 "공격"
                    if (theEnemy.HP >= LowHealthThreshold)
                    {
                        // 공격거리보다 가까워졌다면 "공격"
                        if (distanceToTarget <= attackStartDistance)
                        {
                            SetState(EnemyState.Attack);
                        }
                        // 공격거리보다 멀다 "추격(현재상태)"
                        else
                        {
                            // 추격거리보다 멀어졌다  "탐색"
                            if (distanceToTarget > chaseStartDistance)
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

                // [도망 - 일반몹 전용]
                case EnemyState.Run:

                    // 추격 거리보다 작다면 계속 "도망"
                    if (distanceToTarget < chaseStartDistance)
                    {
                        if (isRun == false)
                        {
                            isRun = true;

                            // 현재 바라보는 방향에서 (XZ 평면상) 반대 방향 구하기
                            oppositeDir = new Vector3(-(transform.forward).x, (transform.forward).y, -(transform.forward).z);
                        }

                        // 도망가기(일단 보는 방향 반대방향으로 일자 도망, 좌우는 추가 구현)
                        eRun();

                        // 뛰는 애니메이션 설정
                        animator.SetInteger(SpeedLevel, 2); // 2 : 뛰기

                        // HP가 2/3보다 많다면 다시 추격하기
                        if (theEnemy.HP <= MidHealthThreshold)
                        {
                            isRun = false;

                            SetState(EnemyState.Chase);
                        }
                    }
                    // 추격 거리보다 멀어졌다면 "탐색(순찰)"
                    else
                    {
                        isRun = false;

                        SetState(EnemyState.Patroll);
                    }

                    break;

                default:
                    break;
            }
        }

    }
}
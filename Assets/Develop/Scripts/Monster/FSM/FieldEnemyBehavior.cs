namespace CreatureGrove
{
    public class FieldEnemyBehavior : EnemyBehavior
    {
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

                    // 대기 상태
                    eIdle();

                    //(플레이어와의 거리가) 
                    // 탐색거리보다 가까워졌다  "검색"
                    if (distanceToTarget <= patrolStartDistance)
                    {
                        SetState(EnemyState.Patroll);
                    }
                    break;


                // [탐색(순찰)]
                case EnemyState.Patroll:

                    // 탐색 (순찰)
                    ePatroll();

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

                    // 목표를 향해 걷기
                    eChase();

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
                        // 도망가기(일단 보는 방향 반대방향으로 일자 도망, 좌우는 추가 구현)
                        eRun();

                        // HP가 2/3보다 많다면 다시 추격하기
                        if (theEnemy.HP <= MidHealthThreshold)
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

                default:
                    break;
            }
        }

    }
}
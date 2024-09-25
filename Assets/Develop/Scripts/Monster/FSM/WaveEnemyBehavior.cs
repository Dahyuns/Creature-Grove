using UnityEngine;

namespace CreatureGrove
{
    public class WaveEnemyBehavior : EnemyBehavior
    {
        // 마을 정보
        protected GameObject theTown;
        protected float DistanceToTown { get { return (transform.position - theTown.transform.position).magnitude; } }


        #region 검색
        public LayerMask targetMask;  // 찾고자 하는 오브젝트의 레이어 마스크
        public float searchRadius = 20f;  // 검색 범위

        public void FindNearestObject()
        {
            Collider[] colliders = Physics.OverlapSphere(this.transform.position, searchRadius, targetMask);
            GameObject nearestObject = null;
            float minDistance = Mathf.Infinity;

            foreach (Collider collider in colliders)
            {
                float distance = Vector3.Distance(this.transform.position, collider.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestObject = collider.gameObject;
                }
            }

            if (nearestObject != null)
            {
                theTarget = nearestObject;
            }
            else
            {
                // 검색 범위보다 멀면 타겟을 마을로 잡음. (추격함)
                if (DistanceToTown > searchRadius)
                { 
                    theTarget = theTown; 
                }
            }
        }
        #endregion

        // 처음엔 

        protected override void Awake()
        {
            base.Awake();
            // 참조
            theTown = GameObject.Find("Town");

            // 현재상태 "검색"로 설정
            currentState = EnemyState.Search;
        }

        protected override void Update()
        {
            base.Update();

            // Search - Chase - Run - (Attack)
            switch (currentState)
            {
                // [검색 : 가까운 마을 오브젝트 찾기]
                case EnemyState.Search:

                    // 가만히 있는 애니메이션 설정
                    animator.SetInteger(SpeedLevel, 0); // 0 : Idle

                    // 검색
                    FindNearestObject();

                    if (theTarget != null) //요기ㄱㄱ
                    {
                        SetState(EnemyState.Chase);
                    }
                    else
                    {
                        Debug.Log("타겟을 찾을 수 없습니당 : 마을도 못찾겠어용");
                    }
                    break;


                // [추격]
                case EnemyState.Chase:

                    if (theTarget == null) // null말고,, 비활성화? enabled??
                    {

                    }

                    // 목표를 향해 걷기
                    eChase();

                    // 뛰는 애니메이션 설정
                    animator.SetInteger(SpeedLevel, 2); // 2 : 뛰기

                    // 체력 : 1/3 보다 많으면 "공격"
                    if (theEnemy.HP >= LowHealthThreshold)
                    {
                        // 공격거리보다 가까워졌다면 "공격"
                        if (distanceToTarget <= attackStartDistance)
                        {
                            SetState(EnemyState.Attack);
                        }
                        // 공격거리보다 멀다 "추격(현재상태)"
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
                        // 처음 도망치는 순간에만 반대방향 구하기
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
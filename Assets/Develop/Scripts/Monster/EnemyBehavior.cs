using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyState
    {
        Wait, Attack, Heal, Run, Search, Defend
    }

    // 적의 구체적인 행동 패턴을 정의 ( AI, 움직임, 플레이어를 추적하는 방법 )
    public class EnemyBehavior : MonoBehaviour
    {
        private float searchDistance = 20f;
        private float attackDistance = 20f;

        private Vector3 DirToPlayer;

        // 플레이어의 상태
        private EnemyState currentState;

        // 참조
        private GameObject thePlayer;

        private void Awake()
        {
            thePlayer = GameObject.Find("Player");
            currentState = EnemyState.Wait;
        }

        private void Update()
        {
            DirToPlayer = thePlayer.transform.position - this.transform.position;

            switch (currentState)
            {
                // [대기]
                case EnemyState.Wait:

                    // 플레이어와의 거리가 검색거리보다 가까울때 "검색"
                    if (DirToPlayer.magnitude < searchDistance)
                    {
                        currentState = EnemyState.Search;
                    }
                    // 플레이어와의 거리가 검색거리보다 멀때 "힐"
                    else
                    {
                        // 만약 피가 깎였다면
                        if (GetComponent<Enemy>().IsMaxHp == false)
                        {
                            currentState = EnemyState.Heal;
                        }
                    }
                    break;


                // [공격]
                case EnemyState.Attack:

                    // 한번 공격

                    // 다시 search로 전환
                    currentState = EnemyState.Search;
                    break;



                // [탐색]
                case EnemyState.Search:
                    
                    // 가까워지면 "공격"으로 전환
                    if (DirToPlayer.magnitude < attackDistance)
                    {
                        if (GetComponent<Enemy>().IsMaxHp == true)
                        {

                        }
                        currentState = EnemyState.Attack;
                    }
                    else
                    {
                        // 목표를 향해 걷기
                    }
                    break;


                // [도망] 일반몹 - 체력 일정수준 이하
                case EnemyState.Run:

                    break;


                // [방어] 보스몹 - 체력 일정수준 이하
                case EnemyState.Defend:
                    // 방어 태새 갖추기

                    // 방어력 추가 >> Enemy.takeDamage에서 적용됨

                    break;


                // [치유]
                case EnemyState.Heal:
                    // 힐 한번
                    GetComponent<Enemy>().sHeal();

                    // "대기"로 전환
                    currentState = EnemyState.Wait;
                    break;


                default:
                    break;
            }
        }

    }
}
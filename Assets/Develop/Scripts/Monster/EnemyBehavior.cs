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
                case EnemyState.Wait:

                    // 플레이어와의 거리가 검색거리보다 적을때 "검색"
                    if (DirToPlayer.magnitude < searchDistance)
                    {
                        currentState = EnemyState.Search;
                    }
                    else
                    {
                        if (GetComponent<Enemy>().HpNow)
                        {

                        }
                    }
                    break;



                case EnemyState.Attack:
                    break;




                case EnemyState.Search:
                    // 목표를 향해 걸어가다가
                    
                    // 어느정도 가까워지면 "때리기"로 전환
                    if (DirToPlayer.magnitude < attackDistance)
                    {
                        currentState = EnemyState.Attack;
                    }
                    else
                    {

                    }
                    break;



                case EnemyState.Heal: 
                    break;



                case EnemyState.Run:

                    break;




                case EnemyState.Defend:
                    break;





                default:
                    break;
            }
        }

    }
}
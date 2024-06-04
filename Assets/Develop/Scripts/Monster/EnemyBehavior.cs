using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyState
    {
        Wait, Attack, Heal, Run, Search, Defend
    }

    // ���� ��ü���� �ൿ ������ ���� ( AI, ������, �÷��̾ �����ϴ� ��� )
    public class EnemyBehavior : MonoBehaviour
    {
        private float searchDistance = 20f;
        private float attackDistance = 20f;

        private Vector3 DirToPlayer;

        // �÷��̾��� ����
        private EnemyState currentState;

        // ����
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

                    // �÷��̾���� �Ÿ��� �˻��Ÿ����� ������ "�˻�"
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
                    // ��ǥ�� ���� �ɾ�ٰ�
                    
                    // ������� ��������� "������"�� ��ȯ
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
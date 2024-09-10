using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyState
    {
        Idle, Patroll, Chase, Attack, Defend, Run, Heal
    }

    // ���� ��ü���� �ൿ ������ ���� ( AI, ������, �÷��̾ �����ϴ� ��� )
    public class EnemyBehavior : MonoBehaviour
    {
        // Ž���Ÿ�
        private float patrolStartDistance = 20f;
        // �߰ݰŸ�
        private float chaseStartDistance = 20f;
        // ���ݰŸ�
        private float attackStartDistance = 20f;

        // �ִ� ü���� 2/3
        private float MidHealthThreshold;
        // �ִ� ü���� 1/3
        private float LowHealthThreshold;

        private Vector3 DirToPlayer { get { return thePlayer.gameObject.transform.position - this.transform.position; } }
        private float distanceToPlayer { get { return DirToPlayer.magnitude;  } }

        // �÷��̾��� ����
        private EnemyState currentState;
        private EnemyState beforeState;

        // ����
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
            // ������ �ֱ�
        }

        private void ePatroll()
        {
            // Ž�� (����)
            // ��ε��� ����
        }

        private void eChase()
        {
            // ��ǥ�� ���� �ȱ�
        }

        //(�÷��̾���� �Ÿ���) 
        private void Update()
        {
            switch (currentState)
            {
                // [���]
                case EnemyState.Idle:

                    // ��� ����
                    eIdle();

                    // Ž���Ÿ����� ���������  "�˻�"
                    if (distanceToPlayer <= patrolStartDistance)
                    {
                        SetState(EnemyState.Patroll);
                    }
                    /*
                    // �˻��Ÿ����� �ֶ� "��"
                    else
                    {
                        // ���� �ǰ� �𿴴ٸ�
                        if (GetComponent<Enemy>().IsMaxHp == false)
                        {
                            currentState = EnemyState.Heal;
                        }
                    }
                    */
                    break;


                // [Ž��]
                case EnemyState.Patroll:

                    // Ž�� (����)
                    ePatroll();

                    // �߰ݰŸ����� ���������  "�߰�"
                    if (distanceToPlayer <= chaseStartDistance)
                    {
                        SetState(EnemyState.Chase);
                    }

                    // �߰ݰŸ����� �ִ� "Ž��(�������)"
                    else
                    {
                        // Ž���Ÿ����� �־�����  "���"
                        if (distanceToPlayer > patrolStartDistance)
                        {
                            SetState(EnemyState.Idle);
                        }
                    }

                    break;


                // [�߰�]
                case EnemyState.Chase:

                    // ��ǥ�� ���� �ȱ�
                    eChase();

                    // ü�� > 2/3 "����"
                    if (theEnemy.HP >= MidHealthThreshold)
                    {
                        // ���ݰŸ����� ��������ٸ� "����"
                        if (distanceToPlayer <= attackStartDistance)
                        {
                            SetState(EnemyState.Attack);
                        }
                        // ���ݰŸ����� �ִ� "�߰�(�������)"
                        else
                        {
                            // �߰ݰŸ����� �־�����  "Ž��"
                            if (distanceToPlayer > chaseStartDistance)
                            {
                                SetState(EnemyState.Patroll);
                            }
                        }
                    }

                    // 2/3 > ü�� > 1/3 "��� + ��"
                    else if (theEnemy.HP >= LowHealthThreshold)
                    {
                        SetState(EnemyState.Defend);
                    }

                    // 1/3 > ü��  "���� + ��"
                    else
                    {
                        SetState(EnemyState.Run);
                    }

                    break;


                // [����]
                case EnemyState.Attack:

                    // �ѹ� ����
                    theEnemy.Attack(thePlayer, theEnemy.AtkPower);

                    // �÷��̾ ���� ���� ������ �����ٸ� "����"
                    if (distanceToPlayer > attackStartDistance)
                    {
                        SetState(EnemyState.Chase);
                    }
                    break;


                // [����] �Ϲݸ� - ü�� �������� ����
                case EnemyState.Run:

                    break;


                // [���] ������ - ü�� �������� ����
                case EnemyState.Defend:

                    // ��� �»� ���߱�

                    // ���� �߰� >> Enemy.takeDamage���� �����

                    // ������ �ȹް� ������ ���ϱ�
                    SetState(EnemyState.Heal);

                    break;


                // [ġ��]
                case EnemyState.Heal:

                    // �� �ѹ�
                    theEnemy.sHeal();

                    // �� ���·� 
                    SetState(beforeState);
                    break; 


                default:
                    break;
            }
        }

    }
}
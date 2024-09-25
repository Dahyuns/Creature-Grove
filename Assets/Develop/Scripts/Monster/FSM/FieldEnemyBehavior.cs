using UnityEngine;

namespace CreatureGrove
{
    public class FieldEnemyBehavior : EnemyBehavior
    {
        // Ž�� ���� �Ÿ�
        protected float patrolStartDistance = 20f;

        // Ž�� (����)
        protected virtual void ePatroll()
        {
            // ��ǥ�������� �̵�
        }

        protected override void Awake()
        {
            base.Awake();

            // ������� "���"�� ����
            currentState = EnemyState.Idle;
        }

        protected override void Update()
        {
            base.Update();

            // Idle - Patroll - Chase - Run - (Attack)
            switch (currentState)
            {
                // [���]
                case EnemyState.Idle:

                    // ������ �ִ� �ִϸ��̼� ����
                    animator.SetInteger(SpeedLevel, 0); // Idle

                    //(�÷��̾���� �Ÿ���) 
                    // Ž���Ÿ����� ���������  "�˻�"
                    if (distanceToTarget <= patrolStartDistance)
                    {
                        SetState(EnemyState.Patroll);
                    }

                    break;

                // �̵� ���� ���߱�
                // agent.isStopped = true;  // ����
                // agent.isStopped = false; // �ٽ� �̵� ����

                // [Ž��(����)]
                case EnemyState.Patroll:

                    // Ž�� (����)
                    ePatroll();

                    // �ȴ� �ִϸ��̼� ����
                    animator.SetInteger(SpeedLevel, 1); // 1 : �ȱ�

                    // �߰ݰŸ����� ���������  "�߰�"
                    if (distanceToTarget <= chaseStartDistance)
                    {
                        SetState(EnemyState.Chase);
                    }

                    // �߰ݰŸ����� �ִ� "Ž��(�������)"
                    else
                    {
                        // Ž���Ÿ����� �־�����  "���"
                        if (distanceToTarget > patrolStartDistance)
                        {
                            SetState(EnemyState.Idle);
                        }
                    }
                    break;


                // [�߰�]
                case EnemyState.Chase:

                    // ��ǥ�� ���� �ٱ�
                    eChase();

                    // �ٴ� �ִϸ��̼� ����
                    animator.SetInteger(SpeedLevel, 2); // �ٱ�

                    // ü�� : 1/3 ���� ������ "����"
                    if (theEnemy.HP >= LowHealthThreshold)
                    {
                        // ���ݰŸ����� ��������ٸ� "����"
                        if (distanceToTarget <= attackStartDistance)
                        {
                            SetState(EnemyState.Attack);
                        }
                        // ���ݰŸ����� �ִ� "�߰�(�������)"
                        else
                        {
                            // �߰ݰŸ����� �־�����  "Ž��"
                            if (distanceToTarget > chaseStartDistance)
                            {
                                SetState(EnemyState.Patroll);
                            }
                        }
                    }
                    // ü�� : 1/3 ���� ������ "����"
                    else
                    {
                        SetState(EnemyState.Run);
                    }
                    break;

                // [���� - �Ϲݸ� ����]
                case EnemyState.Run:

                    // �߰� �Ÿ����� �۴ٸ� ��� "����"
                    if (distanceToTarget < chaseStartDistance)
                    {
                        if (isRun == false)
                        {
                            isRun = true;

                            // ���� �ٶ󺸴� ���⿡�� (XZ ����) �ݴ� ���� ���ϱ�
                            oppositeDir = new Vector3(-(transform.forward).x, (transform.forward).y, -(transform.forward).z);
                        }

                        // ��������(�ϴ� ���� ���� �ݴ�������� ���� ����, �¿�� �߰� ����)
                        eRun();

                        // �ٴ� �ִϸ��̼� ����
                        animator.SetInteger(SpeedLevel, 2); // 2 : �ٱ�

                        // HP�� 2/3���� ���ٸ� �ٽ� �߰��ϱ�
                        if (theEnemy.HP <= MidHealthThreshold)
                        {
                            isRun = false;

                            SetState(EnemyState.Chase);
                        }
                    }
                    // �߰� �Ÿ����� �־����ٸ� "Ž��(����)"
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
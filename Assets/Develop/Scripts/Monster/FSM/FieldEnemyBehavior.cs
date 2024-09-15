namespace CreatureGrove
{
    public class FieldEnemyBehavior : EnemyBehavior
    {
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

                    // ��� ����
                    eIdle();

                    //(�÷��̾���� �Ÿ���) 
                    // Ž���Ÿ����� ���������  "�˻�"
                    if (distanceToTarget <= patrolStartDistance)
                    {
                        SetState(EnemyState.Patroll);
                    }
                    break;


                // [Ž��(����)]
                case EnemyState.Patroll:

                    // Ž�� (����)
                    ePatroll();

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

                    // ��ǥ�� ���� �ȱ�
                    eChase();

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
                        // ��������(�ϴ� ���� ���� �ݴ�������� ���� ����, �¿�� �߰� ����)
                        eRun();

                        // HP�� 2/3���� ���ٸ� �ٽ� �߰��ϱ�
                        if (theEnemy.HP <= MidHealthThreshold)
                        {
                            SetState(EnemyState.Chase);
                        }
                    }
                    // �߰� �Ÿ����� �־����ٸ� "Ž��(����)"
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
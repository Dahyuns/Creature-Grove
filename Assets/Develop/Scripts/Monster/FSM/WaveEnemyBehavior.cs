using UnityEngine;

namespace CreatureGrove
{
    public class WaveEnemyBehavior : EnemyBehavior
    {
        // ���� ����
        protected GameObject theTown;
        protected float DistanceToTown { get { return (transform.position - theTown.transform.position).magnitude; } }


        #region �˻�
        public LayerMask targetMask;  // ã���� �ϴ� ������Ʈ�� ���̾� ����ũ
        public float searchRadius = 20f;  // �˻� ����

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
                // �˻� �������� �ָ� Ÿ���� ������ ����. (�߰���)
                if (DistanceToTown > searchRadius)
                { 
                    theTarget = theTown; 
                }
            }
        }
        #endregion

        // ó���� 

        protected override void Awake()
        {
            base.Awake();
            // ����
            theTown = GameObject.Find("Town");

            // ������� "�˻�"�� ����
            currentState = EnemyState.Search;
        }

        protected override void Update()
        {
            base.Update();

            // Search - Chase - Run - (Attack)
            switch (currentState)
            {
                // [�˻� : ����� ���� ������Ʈ ã��]
                case EnemyState.Search:

                    // ������ �ִ� �ִϸ��̼� ����
                    animator.SetInteger(SpeedLevel, 0); // 0 : Idle

                    // �˻�
                    FindNearestObject();

                    if (theTarget != null) //��⤡��
                    {
                        SetState(EnemyState.Chase);
                    }
                    else
                    {
                        Debug.Log("Ÿ���� ã�� �� �����ϴ� : ������ ��ã�ھ��");
                    }
                    break;


                // [�߰�]
                case EnemyState.Chase:

                    if (theTarget == null) // null����,, ��Ȱ��ȭ? enabled??
                    {

                    }

                    // ��ǥ�� ���� �ȱ�
                    eChase();

                    // �ٴ� �ִϸ��̼� ����
                    animator.SetInteger(SpeedLevel, 2); // 2 : �ٱ�

                    // ü�� : 1/3 ���� ������ "����"
                    if (theEnemy.HP >= LowHealthThreshold)
                    {
                        // ���ݰŸ����� ��������ٸ� "����"
                        if (distanceToTarget <= attackStartDistance)
                        {
                            SetState(EnemyState.Attack);
                        }
                        // ���ݰŸ����� �ִ� "�߰�(�������)"
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
                        // ó�� ����ġ�� �������� �ݴ���� ���ϱ�
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
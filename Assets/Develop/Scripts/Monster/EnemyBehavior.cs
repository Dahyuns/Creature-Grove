using System.Collections;
using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyState
    {
        Idle, Patroll, Chase, Attack, Defend, Run, Heal
       // ����Wave���� (Gathering, Attacking town...) ���� �ϳ� �� ������ �����, ������ ������? �ƴ� damageable ��ü���??
    }

    // ���� ��ü���� �ൿ ������ ���� ( AI, ������, �÷��̾ �����ϴ� ��� )
    public class EnemyBehavior : MonoBehaviour
    {
        // ����
        private Player thePlayer;
        private Enemy theEnemy;

        // [����]
        private EnemyState currentState;
        private EnemyState beforeState;

        // [���� �Ÿ�]
        private float patrolStartDistance = 20f; // Ž��
        private float chaseStartDistance = 20f;  // �߰�
        private float attackStartDistance = 20f; // ����

        // [���� (�÷��̾������) ���� ���Ϳ� �Ÿ�]
        private Vector3 DirToPlayer { get { return thePlayer.gameObject.transform.position - this.transform.position; } }
        private float distanceToPlayer { get { return DirToPlayer.magnitude; } }

        // �ִ� ü���� 2/3,  1/3
        private float MidHealthThreshold;
        private float LowHealthThreshold;


        private bool isAttack = false;
        private bool isHeal = false;
        private bool isDamaged = false;
        //private bool isDefend = false;   //[��� - ������]

        private float atkTimer = 1.5f;
        private float healTimer = 3f;
        private float damagedTimer = 8f;
        //private float defendTimer = 3f;   //[��� - ������]

        private void SetState(EnemyState state)
        {
            beforeState = currentState;
            currentState = state;
        }

        // ���� ��������
        #region ��������Լ�
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

        private void eRun()
        {
            // ���ִ� ���� �ݴ������� ���� �̵�
        }

        private void eHeal()
        {
            theEnemy.Heal();
        }
        #endregion

        /// <summary>
        /// �������� �ȹް� �������� "��" ���·� ��ȯ���ݴϴ�!
        /// </summary>
        private void callHeal()
        {
            // ������ �ȹް� ������
            if (isDamaged == false)
            {
                SetState(EnemyState.Heal);
            }
        }

        #region ��Ÿ��
        // ����
        private IEnumerator AttackCooldown(float duration)
        {
            isAttack = true;
            yield return new WaitForSeconds(duration);
            isAttack = false;
        }

        // ��
        private IEnumerator healCooldown(float duration)
        {
            isHeal = true;
            yield return new WaitForSeconds(duration);
            isHeal = false;
        }

        // �������ް� �ð� ��� (8��)
        public void DamageTimer()
        {
            StartCoroutine(demagedCooldown(damagedTimer));
        }

        private IEnumerator demagedCooldown(float duration)
        {
            isDamaged = true;
            yield return new WaitForSeconds(duration);
            isDamaged = false;

        }

        // ��� [������ ����]
        /*
        private IEnumerator defendCooldown(float duration)
        {
            isDefend = true;
            yield return new WaitForSeconds(duration);
            isDefend = false;
        }
        */
        #endregion

        private void Awake()
        {
            // ����
            thePlayer = GameObject.Find("Player").GetComponent<Player>();
            theEnemy = GetComponent<Enemy>();

            // ������� "���"�� ����
            currentState = EnemyState.Idle;
        }

        private void Update()
        {
            //(�÷��̾���� �Ÿ���) 
            switch (currentState)
            {
                // [���]
                case EnemyState.Idle:

                    // ��� ����
                    eIdle();

                    // �ִ� ü�±��� ���ϱ�
                    if (theEnemy.IsMaxHp == false)
                    {
                        callHeal();
                    }

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


                // [Ž��(����)]
                case EnemyState.Patroll:

                    // Ž�� (����)
                    ePatroll();

                    // �ִ� ü�±��� ���ϱ�
                    if (theEnemy.IsMaxHp == false)
                    {
                        callHeal();
                    }

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

                    // �ִ� ü�±��� ���ϱ�
                    if (theEnemy.IsMaxHp == false)
                    {
                        callHeal();
                    }

                    // ü�� : 1/3 ���� ������ "����"
                    if (theEnemy.HP >= LowHealthThreshold)
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
                    // ü�� : 1/3 ���� ������ "����"
                    else
                    {
                        SetState(EnemyState.Run);
                    }

                    break;


                // [����]
                case EnemyState.Attack:

                    // ���� ��Ÿ���� �ƴ϶��
                    if(isAttack == false)
                    {
                        // ���� Ÿ�̸� ON (isHeal == true)
                        StartCoroutine(AttackCooldown(atkTimer));

                        // �ѹ� ����
                        theEnemy.Attack(thePlayer, theEnemy.AtkPower);
                    }

                    // �÷��̾ ���� ���� ������ �����ٸ� "����"
                    if (distanceToPlayer > attackStartDistance)
                    {
                        SetState(EnemyState.Chase);
                    }
                    break;


                // [���� - �Ϲݸ� ����]
                case EnemyState.Run:

                    // �߰� �Ÿ����� �۴ٸ� ��� "����"
                    if (distanceToPlayer < chaseStartDistance)
                    {
                        // ��������(�ϴ� ���� ���� �ݴ�������� ���� ����, �¿�� �߰� ����)
                        eRun();

                        // (ü����)
                        // 2/3���� ���ٸ� �� (���� ���鼭 ���Ǵ� ��)
                        if (theEnemy.HP < MidHealthThreshold)
                        {
                            callHeal();
                        }
                        // 2/3���� ���ٸ� �ٽ� �߰��ϱ�
                        else
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


                // [ġ��]
                case EnemyState.Heal:

                    // �� ���� �ȵ��Ҵٸ�
                    if (isHeal == false)
                    {
                        // �� Ÿ�̸� (���� isHeal == true)
                        StartCoroutine(healCooldown(healTimer));

                        // �� �ѹ�
                        eHeal();

                    }

                    // �� ���·� 
                    SetState(beforeState);

                    break;


                // [��� - ���� ����] ���� �̱���
                /*
                case EnemyState.Defend:

                    // ��� ��Ÿ���� �ƴ϶��
                    if (isDefend == false)
                    {
                        // ��� �»� ���߱�, ����߿� true
                        // ���� �߰� >> Enemy.takeDamage���� �����
                    }

                    // ������ �ȹް� ������ ���ϱ�
                    if (isDamaged == false)
                    {
                        SetState(EnemyState.Heal);
                    }      

                    break;
                */


                default:
                    break;
            }
        }

    }
}
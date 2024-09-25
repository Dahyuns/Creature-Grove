using System.Collections;
using UnityEngine;

namespace CreatureGrove
{
    public enum EnemyState
    {
        // field��
        Idle, Patroll, Chase, Attack, Run,

        // wave��
        Search,

        // boss��
        Defend
    }
    
    //���� ������ fsm �۵��Ǵ��� ��������!
    public class EnemyBehavior : MonoBehaviour
    {
        // ����
        protected Animator animator;
        protected GameObject theTarget;

        // [���� (Ÿ�ٱ�����) ���� ���Ϳ� �Ÿ�]
        protected float distanceToTarget { get { return (theTarget.transform.position - this.transform.position).magnitude; } }

        // [Run]
        protected bool isRun = false;
        protected Vector3 oppositeDir = Vector3.zero;
        protected float walkSpeed = 10f;

        // [���� �Ÿ�]
        protected float chaseStartDistance = 20f;  // �߰�
        protected float attackStartDistance = 20f; // ����

        // �ִ� ü���� 2/3,  1/3
        protected float MidHealthThreshold;
        protected float LowHealthThreshold;

        // animation strings
        protected string AttackTrigger = "Attack";
        protected string SpeedLevel = "Speed";

        #region [FSM]
        protected EnemyState currentState;
        protected EnemyState beforeState;

        // ���� ����
        protected void SetState(EnemyState newState)
        {
            // ���� ���� üũ
            if (currentState == newState)
                return;

            // ���� ����
            beforeState = currentState;
            currentState = newState;

            // ���� ���濡 ���� �ִϸ��̼� ����
            // ����, ����������, ���� ���� �� IDLE!
            //animator.SetInteger(enemyState, (int)currentState);
        }
        #endregion

        #region ��Ÿ��
        protected bool isAttack = false;
        protected bool isHeal = false;
        protected bool isDamaged = false;

        protected float atkTimer = 1.5f;
        protected float healTimer = 3f;
        protected float damagedTimer = 8f;

        // ����
        protected IEnumerator AttackCooldown()
        {
            isAttack = true;
            yield return new WaitForSeconds(atkTimer);
            isAttack = false;
        }

        // ��
        protected IEnumerator healCooldown()
        {
            isHeal = true;
            yield return new WaitForSeconds(healTimer);
            isHeal = false;
        }

        // �������ް� �ð� ��� (8��)
        public void DamageTimer()
        {
            StartCoroutine(demagedCooldown(damagedTimer));
        }

        protected IEnumerator demagedCooldown(float duration)
        {
            isDamaged = true;
            yield return new WaitForSeconds(duration);
            isDamaged = false;

        }
        #endregion

        // ��ǥ�� ���� �ȱ�
        protected virtual void eChase()
        {
            // �� ������Ʈ ���̿� ����
            Vector3 tg = new Vector3(theTarget.transform.position.x, this.transform.position.y, theTarget.transform.position.z);

            // Ÿ�ٱ����� ����
            Vector3 dir = tg - this.transform.position;

            // �̵�
            transform.Translate(dir.normalized * Time.deltaTime * walkSpeed, Space.World);

            // ȸ��
            transform.LookAt(tg);
        }

        // �ٸ� �������� ����ġ��
        protected virtual void eRun()
        {
            // �ݴ� �������� �̵��� ��
            transform.Translate(oppositeDir.normalized * Time.deltaTime * walkSpeed, Space.World);
        }

        // �� : GlobalState
        #region  �� [�������� �ȹް�,��Ÿ��, MaxHP�� �ƴҶ�]
        protected void GlobalLogicHeal()
        {
            // �� ���� �ȵ��Ҵٸ�
            if (isHeal == false)
            {
                // �� Ÿ�̸� (���� isHeal == true)
                StartCoroutine(healCooldown());

                // �ִ� ü�±��� ���ϱ�
                if (theEnemy.IsMaxHp == false)
                {
                    // ������ �ȹް� ������
                    if (isDamaged == false)
                    {
                        theEnemy.Heal();
                    }
                }
            }
        }
        #endregion

        protected Enemy theEnemy;

        protected virtual void Awake()
        {
            // ����
            theTarget = GameObject.Find("Player");
            theEnemy = GetComponent<Enemy>();
            animator = GetComponent<Animator>();
        }

        protected virtual void Update()
        {
            if (theEnemy.IsDead)
                return;

            // [GlobalState]
            GlobalLogicHeal();

            switch (currentState)
            {
                // [����]
                case EnemyState.Attack:

                    // ���� ��Ÿ���� �ƴ϶��
                    if (isAttack == false)
                    {
                        // ���� Ÿ�̸� ON (isHeal == true)
                        StartCoroutine(AttackCooldown());

                        // �ѹ� ����
                        theEnemy.Attack(theTarget.GetComponent<IDamageManager>(), theEnemy.AtkPower);

                        // �ִϸ��̼�
                        animator.SetTrigger(AttackTrigger);
                    }

                    // �÷��̾ ���� ���� ������ �����ٸ� "����"
                    if (distanceToTarget > attackStartDistance)
                    {
                        SetState(EnemyState.Chase);
                    }
                    break;
            }
        }
    }
}
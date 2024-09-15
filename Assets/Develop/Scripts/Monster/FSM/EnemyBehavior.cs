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

    public class EnemyBehavior : MonoBehaviour
    {
        // ����
        protected GameObject theTarget;
        protected Enemy theEnemy;

        // [���� (�÷��̾������) ���� ���Ϳ� �Ÿ�]
        protected float distanceToTarget { get { return (theTarget.transform.position - this.transform.position).magnitude; } }

        // [���� �Ÿ�]
        protected float patrolStartDistance = 20f; // Ž��
        protected float chaseStartDistance = 20f;  // �߰�
        protected float attackStartDistance = 20f; // ����

        // �ִ� ü���� 2/3,  1/3
        protected float MidHealthThreshold;
        protected float LowHealthThreshold;

        // �̰� enemy���� �������°� ��������?
        protected float walkSpeed = 10f;

        #region ��Ÿ�ӿ� 
        protected bool isAttack = false;
        protected bool isHeal = false;
        protected bool isDamaged = false;

        protected float atkTimer = 1.5f;
        protected float healTimer = 3f;
        protected float damagedTimer = 8f;
        #endregion

        // [����]
        protected EnemyState currentState;
        protected EnemyState beforeState;

        // ���� ��������
        #region ��������Լ�
        protected virtual void eIdle()
        {
            // ������ �ֱ�
        }

        protected virtual void ePatroll()
        {
            // Ž�� (����)
            // ��ε��� ����
        }

        protected virtual void eChase()
        {
            // ��ǥ�� ���� �ȱ�
            WalkTo(theTarget.transform);
        }

        protected virtual void eRun()
        {
            // ���ִ� ���� �ݴ������� ���� �̵�
        }

        protected virtual void eHeal()
        {
            theEnemy.Heal();
        }

        protected void eSearch()
        {
            // ���� ����� ���� ������Ʈ �˻�
        }

        protected void WalkTo(Transform tr)
        {
            this.transform.Translate(tr.position.normalized * walkSpeed * Time.deltaTime);
        }
        #endregion

        protected virtual void Awake()
        {
            // ����
            theTarget = GameObject.Find("Player");
            theEnemy = GetComponent<FieldEnemy>();
        }

        protected virtual void Update()
        {
            GlobalLogicHeal();

            switch (currentState)
            {
                // [����]
                case EnemyState.Attack:

                    // ���� ��Ÿ���� �ƴ϶��
                    if (isAttack == false)
                    {
                        // ���� Ÿ�̸� ON (isHeal == true)
                        StartCoroutine(AttackCooldown(atkTimer));

                        // �ѹ� ����
                        theEnemy.Attack(theTarget.GetComponent<IDamageManager>(), theEnemy.AtkPower);
                    }
                    else
                    {
                        // ������ ������ �ִϸ��̼�... �߰� ����
                    }

                    // �÷��̾ ���� ���� ������ �����ٸ� "����"
                    if (distanceToTarget > attackStartDistance)
                    {
                        SetState(EnemyState.Chase);
                    }
                    break;
            }
        }

        protected void SetState(EnemyState state)
        {
            beforeState = currentState;
            currentState = state;
        }

        /// <summary>
        ///  �� !!
        /// [�������� �ȹް�,�� ��Ÿ��, Max�ǰ� �ƴҶ�]
        /// </summary>
        protected void GlobalLogicHeal()
        {
            // �� ���� �ȵ��Ҵٸ�
            if (isHeal == false)
            {
                // �� Ÿ�̸� (���� isHeal == true)
                StartCoroutine(healCooldown(healTimer));

                // �ִ� ü�±��� ���ϱ�
                if (theEnemy.IsMaxHp == false)
                {
                    // ������ �ȹް� ������
                    if (isDamaged == false)
                    {
                        eHeal();
                    }
                }
            }
        }

        #region ��Ÿ��
        // ����
        protected IEnumerator AttackCooldown(float duration)
        {
            isAttack = true;
            yield return new WaitForSeconds(duration);
            isAttack = false;
        }

        // ��
        protected IEnumerator healCooldown(float duration)
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

        protected IEnumerator demagedCooldown(float duration)
        {
            isDamaged = true;
            yield return new WaitForSeconds(duration);
            isDamaged = false;

        }
        #endregion
    }
}
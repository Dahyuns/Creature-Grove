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
                // [���]
                case EnemyState.Wait:

                    // �÷��̾���� �Ÿ��� �˻��Ÿ����� ����ﶧ "�˻�"
                    if (DirToPlayer.magnitude < searchDistance)
                    {
                        currentState = EnemyState.Search;
                    }
                    // �÷��̾���� �Ÿ��� �˻��Ÿ����� �ֶ� "��"
                    else
                    {
                        // ���� �ǰ� �𿴴ٸ�
                        if (GetComponent<Enemy>().IsMaxHp == false)
                        {
                            currentState = EnemyState.Heal;
                        }
                    }
                    break;


                // [����]
                case EnemyState.Attack:

                    // �ѹ� ����

                    // �ٽ� search�� ��ȯ
                    currentState = EnemyState.Search;
                    break;



                // [Ž��]
                case EnemyState.Search:
                    
                    // ��������� "����"���� ��ȯ
                    if (DirToPlayer.magnitude < attackDistance)
                    {
                        if (GetComponent<Enemy>().IsMaxHp == true)
                        {

                        }
                        currentState = EnemyState.Attack;
                    }
                    else
                    {
                        // ��ǥ�� ���� �ȱ�
                    }
                    break;


                // [����] �Ϲݸ� - ü�� �������� ����
                case EnemyState.Run:

                    break;


                // [���] ������ - ü�� �������� ����
                case EnemyState.Defend:
                    // ��� �»� ���߱�

                    // ���� �߰� >> Enemy.takeDamage���� �����

                    break;


                // [ġ��]
                case EnemyState.Heal:
                    // �� �ѹ�
                    GetComponent<Enemy>().sHeal();

                    // "���"�� ��ȯ
                    currentState = EnemyState.Wait;
                    break;


                default:
                    break;
            }
        }

    }
}
using UnityEngine;
using UnityEngine.InputSystem;

namespace CreatureGrove
{
    public class PlayerSkillBasic : MonoBehaviour
    {
        // ����
        private Rigidbody rb;

        // ĳ���Ͱ� �ٴڿ� �������� ���̰�
        private float playerPosY;

        // [Tumble]
        // ��ǥ �������� Ư�� �Ÿ���ŭ ������!
        // ��ǥ ���� : ���콺 ��ġ
        private Vector3 tumbleTarget;

        // ������ (�ִ�)�Ÿ�
        private float tumbleDistanceMax = 4f;

        // ���ݱ��� ���� �Ÿ�
        private float currentTumbleDistance = 0f;

        // ������ �ӵ� (Lerp : 0-1����)
        private float tumbleSpeed = 2f;

        // ���������ΰ�? ������ �� + ��Ÿ�ӿ� �����Ⱑ �ȵǾ���
        private bool isTumble;

        private Vector3 tumbleDir;
        
        void Awake()
        {
            // [jump] �ʱ�ȭ
            rb = GetComponent<Rigidbody>();
            playerPosY = transform.position.y;
        }

        void Update()
        {
            if (isTumble)
            {
                //������
                Tumble();

                // ���� ���� �Ÿ��� �ִ� �Ÿ��� ���ٸ�? (���� : ������Ʈ �浹)
                if (currentTumbleDistance >= tumbleDistanceMax - (0.01f)) // lerp����� ���� ����Ȯ��
                {
                    isTumble = false;
                    currentTumbleDistance = 0f;
                }
            }
        }

        void Tumble()
        {
            transform.position = Vector3.Lerp(transform.position,tumbleDir, tumbleSpeed);
        }

        void OnTumble(InputValue value)
        {
            if (isTumble == false)
            {
                isTumble = true;

                // ������ ���ⱸ�ϱ�(�������� * �ִ�Ÿ�)
                tumbleDir = Camera.main.ScreenToWorldPoint(tumbleTarget) - this.transform.position;
                tumbleDir = tumbleDir.normalized * tumbleDistanceMax;
            }
        }

        void OnJump()
        {
            // ���� y��ǥ (+��������) �϶��� ���� ����
            if (transform.position.y < (playerPosY + 0.01))
            {
                rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            }
        }

        // �������� "������Ʈ�� �ε�����"�� �������� ���� 
        private void OnCollisionEnter(Collision collision)
        {
            if (isTumble)
            {
                if (collision.gameObject.tag == "������Ʈ")
                {
                    currentTumbleDistance = tumbleDistanceMax;
                }
            }
        }
    }

}
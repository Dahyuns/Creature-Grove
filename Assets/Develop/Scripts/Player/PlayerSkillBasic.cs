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

        // ������ �ӵ�? (�Ÿ��� �ð�)
        private float tumbleTimeOrSpeed = 2f;

        // ���ݱ��� ���� �ð�
        private float currentTumbleTime = 0f;

        // ���������ΰ�?
        private bool isTumble;

        void Awake()
        {
            // [jump] �ʱ�ȭ
            rb = GetComponent<Rigidbody>();
            playerPosY = transform.position.y;
        }

        void Update()
        {
            Tumble();

            if (isTumble)
            {

                //if (transform.position == )
                {
                    isTumble = false;
                }
            }
        }

        void Tumble()
        {
            //������ �Ÿ��� �ִ�Ÿ����� �۾ƾ��ϰ�, �۰� ������ �ð��� ª�������ϰ�, ������ �� + ��Ÿ�ӿ� �����Ⱑ �ȵǾ���
            //




            //Vector3 newPosition =  
            //transform.position = newPosition;
        }

        void OnTumble(InputValue value)
        {
            if (isTumble == false)
            {
                //targetPoint = Input.mousePosition; Camera.main.ScreenToWorldPoint(pos);
                isTumble = true;
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


        // ��ǥ ���������� ���� : "���� ��ġ - ��ǥ ����"
        private Vector3 tumbleDir;
        //  tumbleDir = transform.position - tumbleTarget;
    }

}
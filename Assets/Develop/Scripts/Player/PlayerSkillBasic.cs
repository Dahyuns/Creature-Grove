using UnityEngine;
using UnityEngine.InputSystem;

namespace CreatureGrove
{
    public class PlayerSkillBasic : MonoBehaviour
    {
        // [Tumble]
        // ��ǥ �������� Ư�� �Ÿ���ŭ ������!
        // ��ǥ ���� : ���콺 ��ġ
        private Vector3 tumbleTarget;

        // ������ (�ִ�)�Ÿ�
        private float tumbleDistanceMax = 4f;

        // ���ݱ��� ���� �Ÿ�
        private float currentTumbleDistance = 0f;

        // ������ �ӵ� (Lerp : 0-1����)
        private float tumbleSpeed = 0.2f;

        // ���������ΰ�? ������ �� + ��Ÿ�ӿ� �����Ⱑ �ȵǾ���
        private bool isTumble;

        private Vector3 tumbleDir;

        private Gun gun;
        private Bow bow;

        private void Awake()
        {
            switch (Player.WeaponType)
            {
                case WeaponType.Gun:
                    gun = this.gameObject.GetComponent<Player>().Thisweapon.GetComponent<Gun>();
                    break;

                case WeaponType.Bow:
                    bow = this.gameObject.GetComponent<Player>().Thisweapon.GetComponent<Bow>();
                    break;

                default:
                    break;
            }
        }

        void Update()
        {
            if (isTumble)
            {
                // ������
                Tumble();

                // ���� ���� �Ÿ��� �ִ� �Ÿ��� ���ٸ�? (���� : ������Ʈ �浹)
                if (currentTumbleDistance >= tumbleDistanceMax - (0.01f)) // lerp����� ���� ����Ȯ��
                {
                    Debug.Log("not Tumble");
                    isTumble = false;
                    currentTumbleDistance = 0f;
                }
            }
        }

        void Tumble()
        {
            // �ε巴�� ������
            transform.position = Vector3.Lerp(transform.position,tumbleDir, tumbleSpeed);

            // ���� �Ÿ� �߰�

        }

        void OnTumble(InputValue value)
        {
            if (isTumble == false)
            {
                Debug.Log("is Tumble");
                isTumble = true;

                // ���콺 ������ ��ġ
                tumbleTarget = Input.mousePosition;

                // ������ ���ⱸ�ϱ�(�������� * �ִ�Ÿ�)
                tumbleDir = Camera.main.ScreenToWorldPoint(tumbleTarget) - this.transform.position;
                tumbleDir = tumbleDir.normalized * tumbleDistanceMax;
            }
        }

        void OnFire(InputValue value)
        {
            switch (Player.WeaponType)
            {
                case WeaponType.Gun:
                    gun.fireProjectile();
                    break;

                case WeaponType.Bow:
                    bow.fireProjectile();
                    break;

                default:
                    break;
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
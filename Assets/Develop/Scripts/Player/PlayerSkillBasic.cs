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

        //private WeaponType weaponType;

        private string weaponTag = "Weapon";

        private GameObject thisWeapon;

        private Weapon weapon;

        void Start()
        {
            // ���� �±׸� ���� ������Ʈ�� ã��
            thisWeapon = GameObject.FindGameObjectWithTag(weaponTag);
            // ���������Ʈ�� Ŭ������ ��ĳ����
            switch (Weapon.weaponType)
            {
                case WeaponType.Gun:
                    weapon = thisWeapon.GetComponent<Gun>();
                    break;

                case WeaponType.Bow:
                    weapon = thisWeapon.GetComponent<Bow>();
                    break;
            }

            /*
             * 
            //weaponType = GetComponent<Player>().WeaponType;
            switch (weaponType)
            {
                case WeaponType.Gun:
                    gun = GetComponent<Player>().Thisweapon.GetComponent<Gun>();
                    break;

                case WeaponType.Bow:
                    bow = GetComponent<Player>().Thisweapon.GetComponent<Bow>();
                    break;

                default:
                    break;
            }*/
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
            weapon.fireProjectile();
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
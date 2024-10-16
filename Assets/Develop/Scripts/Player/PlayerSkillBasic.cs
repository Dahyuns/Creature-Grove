using UnityEngine;
using UnityEngine.InputSystem;

namespace CreatureGrove
{
    public class PlayerSkillBasic : MonoBehaviour
    {
        #region [Tumble]
        // 목표 방향으로 특정 거리만큼 구르기!
        // 목표 지점 : 마우스 위치
        private Vector3 tumbleTarget;

        // 구르기 (최대)거리
        private float tumbleDistanceMax = 4f;

        // 지금까지 구른 거리
        private float currentTumbleDistance = 0f;

        // 구르기 속도 (Lerp : 0-1사이)
        private float tumbleSpeed = 0.2f;

        // 구르는중인가? 구르는 중 + 쿨타임엔 구르기가 안되야함
        private bool isTumble;

        private Vector3 tumbleDir;
        #endregion


        #region [Interect]
        private PlayerViewRaycaster ObCamera;

        public void OnInteract(InputValue value)
        {
            if (value.isPressed)
            {
                ObCamera.ToggleButtonState();
                Debug.Log("버튼이 눌렸습니다.");
            }
            else // 버튼이 떼어졌을 때
            {
                ObCamera.ToggleButtonState();
                Debug.Log("버튼이 떼어졌습니다.");
            }
        }
        #endregion 


        #region [Fire]
        // 참조
        private GameObject thisWeapon;
        private Weapon weapon;

        void Start()
        {
            // 1인칭 카메라를 찾음!
            ObCamera = GameObject.Find("Main Camera").GetComponent<PlayerViewRaycaster>();

            // 무기 태그를 가진 오브젝트를 찾음
            thisWeapon = GameObject.FindGameObjectWithTag(GameStrings.WeaponTag);

            // 무기오브젝트의 클래스를 업캐스팅
            switch (Weapon.weaponType)
            {
                case WeaponType.Gun:
                    weapon = thisWeapon.GetComponent<Gun>();
                    break;

                case WeaponType.Bow:
                    weapon = thisWeapon.GetComponent<Bow>();
                    break;
            }
        }

        void OnFire(InputValue value)
        {
            weapon.fireProjectile();
        }
        #endregion

        #region [Tumble]

        void Update()
        {
            if (isTumble)
            {
                // 구르기
                Tumble();

                // 현재 구른 거리가 최대 거리와 같다면? (예외 : 오브젝트 충돌)
                if (currentTumbleDistance >= tumbleDistanceMax - (0.01f)) // lerp사용을 위한 범위확대
                {
                    Debug.Log("not Tumble");
                    isTumble = false;
                    currentTumbleDistance = 0f;
                }
            }
        }

        void OnTumble(InputValue value)
        {
            if (isTumble == false)
            {
                Debug.Log("is Tumble");
                isTumble = true;

                // 마우스 포인터 위치
                tumbleTarget = Input.mousePosition;

                // 구르기 방향구하기(단위벡터 * 최대거리)
                tumbleDir = Camera.main.ScreenToWorldPoint(tumbleTarget) - this.transform.position;
                tumbleDir = tumbleDir.normalized * tumbleDistanceMax;
            }
        }

        void Tumble()
        {
            // 부드럽게 구르기
            transform.position = Vector3.Lerp(transform.position,tumbleDir, tumbleSpeed);

            // 구른 거리 추가

        }

        // 구르기중 "오브젝트에 부딪힌다"면 움직임을 제한 
        private void OnCollisionEnter(Collision collision)
        {
            if (isTumble)
            {
                if (collision.gameObject.tag == "오브젝트")
                {
                    currentTumbleDistance = tumbleDistanceMax;
                }
            }
        }
        #endregion
    }

}
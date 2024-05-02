using UnityEngine;
using UnityEngine.InputSystem;

namespace CreatureGrove
{
    public class PlayerSkillBasic : MonoBehaviour
    {
        // 참조
        private Rigidbody rb;

        // 캐릭터가 바닥에 있을때의 높이값
        private float playerPosY;

        // [Tumble]
        // 목표 방향으로 특정 거리만큼 구르기!
        // 목표 지점 : 마우스 위치
        private Vector3 tumbleTarget;

        // 구르기 (최대)거리
        private float tumbleDistanceMax = 4f;

        // 구르기 속도? (거리당 시간)
        private float tumbleTimeOrSpeed = 2f;

        // 지금까지 구른 시간
        private float currentTumbleTime = 0f;

        // 구르는중인가?
        private bool isTumble;

        void Awake()
        {
            // [jump] 초기화
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
            //구르는 거리가 최대거리보다 작아야하고, 작게 구르면 시간도 짧아져야하고, 구르는 중 + 쿨타임엔 구르기가 안되야함
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
            // 최초 y좌표 (+오차범위) 일때만 점프 가능
            if (transform.position.y < (playerPosY + 0.01))
            {
                rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            }
        }


        // 목표 지점까지의 방향 : "현재 위치 - 목표 지점"
        private Vector3 tumbleDir;
        //  tumbleDir = transform.position - tumbleTarget;
    }

}
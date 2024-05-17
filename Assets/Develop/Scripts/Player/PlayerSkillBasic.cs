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

        // 지금까지 구른 거리
        private float currentTumbleDistance = 0f;

        // 구르기 속도 (Lerp : 0-1사이)
        private float tumbleSpeed = 2f;

        // 구르는중인가? 구르는 중 + 쿨타임엔 구르기가 안되야함
        private bool isTumble;

        private Vector3 tumbleDir;
        
        void Awake()
        {
            // [jump] 초기화
            rb = GetComponent<Rigidbody>();
            playerPosY = transform.position.y;
        }

        void Update()
        {
            if (isTumble)
            {
                //구르기
                Tumble();

                // 현재 구른 거리가 최대 거리와 같다면? (예외 : 오브젝트 충돌)
                if (currentTumbleDistance >= tumbleDistanceMax - (0.01f)) // lerp사용을 위한 범위확대
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

                // 구르기 방향구하기(단위벡터 * 최대거리)
                tumbleDir = Camera.main.ScreenToWorldPoint(tumbleTarget) - this.transform.position;
                tumbleDir = tumbleDir.normalized * tumbleDistanceMax;
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
    }

}
using UnityEngine;
using UnityEngine.InputSystem;

namespace CreatureGrove
{
    public class PlayerMove : MonoBehaviour
    {
        // 참조
        private Rigidbody rb;

        // 캐릭터가 바닥에 있을때의 높이값
        private float playerPosY;

        // 이동 및 회전 방향
        private Vector3 dir;
        [SerializeField] private float moveSpeed = 6;
        [SerializeField] private float rotSmoothness = 12;

        void Awake()
        {
            // [jump] 초기화
            rb = GetComponent<Rigidbody>();
            playerPosY = transform.position.y;
        }

        void Update()
        {
            if (dir != Vector3.zero)
            {
                // 이동
                this.transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);


                // 회전
                Vector3 tmp = new Vector3(dir.x, 0, dir.z).normalized;
                Quaternion tmpQ = Quaternion.identity;
                tmpQ.eulerAngles = new Vector3(0, Mathf.Atan2(tmp.x, tmp.z) * Mathf.Rad2Deg, 0);
                //transform.rotation = tmpQ;
                transform.rotation = Quaternion.Lerp(transform.rotation, tmpQ, Time.deltaTime * rotSmoothness);
                //transform.eulerAngles = new Vector3(0, Mathf.Atan2(tmp.x, tmp.z) * Mathf.Atan2(tmp.x, tmp.z) * Mathf.Rad2Deg,0);

            }
            else
            {
            }
        }

        void OnMove(InputValue value)
        {
            if(value != null)
            {
                Vector2 tmp = value.Get<Vector2>();
                dir = new Vector3(tmp.x, 0, tmp.y);
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
    }
}

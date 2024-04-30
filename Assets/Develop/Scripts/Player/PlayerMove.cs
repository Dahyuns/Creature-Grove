using UnityEngine;
using UnityEngine.InputSystem;

namespace CreatureGrove
{
    public class PlayerMove : MonoBehaviour
    {
        private Vector3 dir;
        [SerializeField] private float moveSpeed = 3;
        [SerializeField] private float rotSmoothness = 7;

        void Awake()
        {
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

                // 점프

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
    }
}

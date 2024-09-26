using UnityEngine;

namespace CreatureGrove
{
    public class Bullet : MonoBehaviour
    {
        // 추가? : 오브젝트 풀링
        [SerializeField] private float speed = 300f;
        [SerializeField] private float massValue = 0.1f;
        private float damage;

        private IDamageManager shooter;

        public void ConfigureAndShoot(Transform firePoint, GameObject parent, float value)
        {
            // FirePoint 위치와 방향으로 발사체 위치와 방향 설정
            this.transform.position = firePoint.position;
            this.transform.forward = firePoint.forward;

            // 발사체를 쏜 사람 설정
            shooter = parent.gameObject.GetComponent<IDamageManager>();

            // 발사체 데미지 설정
            damage = value;

            // 발사체 이동 시작
            SetMove();
        }

        void SetMove()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.mass = massValue;
            rb.AddForce(transform.forward * speed);

            Destroy(gameObject,10f);
        }

        private void OnTriggerEnter(Collider other)
        {
            IDamageManager target = other.gameObject.GetComponent<IDamageManager>();

            if (target != null && target != shooter)
            {
                shooter.Attack(target, damage); 


                if (target is Enemy)
                {
                    Debug.Log("적 데미지");
                }
                else if (target is Player)
                {
                    Debug.Log("플레이어 데미지");
                }
            }

            Destroy(gameObject);
        }
    }
}
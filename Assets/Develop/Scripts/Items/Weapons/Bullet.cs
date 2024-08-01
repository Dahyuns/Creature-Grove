using UnityEngine;

namespace CreatureGrove
{
    public class Bullet : MonoBehaviour
    {
        // �߰�? : ������Ʈ Ǯ��
        private Vector3 dir;
        private bool isSet = false;

        private float speed = 1.0f;

        public void SetDir(Transform firePoint)
        {
            this.transform.position = firePoint.position;
            this.transform.forward = firePoint.forward;
            SetMove();
        }

        void SetMove()
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            Destroy(gameObject, 5f);
        }



        private void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("�� ������");
               // enemy.TakeDamage(Gun.effectiveAtkPower());
            }
        }
    }
}
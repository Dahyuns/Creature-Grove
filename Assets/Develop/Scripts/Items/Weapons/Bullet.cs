using UnityEngine;

namespace CreatureGrove
{
    public class Bullet : MonoBehaviour
    {
        // �߰�? : ������Ʈ Ǯ��
        [SerializeField] private float speed = 300f;
        [SerializeField] private float massValue = 0.1f;
        private float damage;

        private IDamageManager shooter;

        public void ConfigureAndShoot(Transform firePoint, GameObject parent, float value)
        {
            // FirePoint ��ġ�� �������� �߻�ü ��ġ�� ���� ����
            this.transform.position = firePoint.position;
            this.transform.forward = firePoint.forward;

            // �߻�ü�� �� ��� ����
            shooter = parent.gameObject.GetComponent<IDamageManager>();

            // �߻�ü ������ ����
            damage = value;

            // �߻�ü �̵� ����
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
                    Debug.Log("�� ������");
                }
                else if (target is Player)
                {
                    Debug.Log("�÷��̾� ������");
                }
            }

            Destroy(gameObject);
        }
    }
}
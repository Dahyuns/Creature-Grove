using UnityEngine;

namespace CreatureGrove
{
    public class Bullet : MonoBehaviour
    {
        // �߰�? : ������Ʈ Ǯ��

        private float speed = 0.5f;
        private float damage = 0f;

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
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            Destroy(gameObject, 5f);
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
        }
    }
}
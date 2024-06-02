using UnityEngine;

namespace CreatureGrove
{
    public class Bullet : MonoBehaviour
    {
        private Vector3 dir;
        private Vector3 firePoint;
        private bool isSet;

        public void SetDir(Vector3 dirIn, Vector3 fpIn)
        {
            dir = dirIn;
            firePoint = fpIn;
            isSet = true;
        }

        private void Awake()
        {
            Destroy(gameObject, 5f);
        }

        private void Update()
        {
            if (isSet)
            {
                transform.Translate(dir);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy == null)
            {
                Debug.Log("적 데미지");
               // enemy.TakeDamage(Gun.effectiveAtkPower());
            }
        }
    }
}
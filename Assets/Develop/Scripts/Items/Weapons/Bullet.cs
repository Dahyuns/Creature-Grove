using UnityEngine;

namespace CreatureGrove
{
    public class Bullet : MonoBehaviour
    {
        // 추가? : 오브젝트 풀링
        private Vector3 dir;
        private bool isSet = false;

        public void SetDir(Vector3 dirIn)
        {
            dir = dirIn;
            transform.position = GameObject.Find("FirePoint").transform.position;
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
                transform.Translate(dir*0.1f,Space.World);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("적 데미지");
               // enemy.TakeDamage(Gun.effectiveAtkPower());
            }
        }
    }
}
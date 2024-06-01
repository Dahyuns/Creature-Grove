using UnityEngine;

namespace CreatureGrove
{
    public class Bullet : MonoBehaviour
    {
        private void Awake()
        {
            Destroy(gameObject, 10f);    
        }

        private void OnCollisionEnter(Collision collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("적 데미지");
               // enemy.TakeDamage(Gun.effectiveAtkPower());
            }
        }
    }
}
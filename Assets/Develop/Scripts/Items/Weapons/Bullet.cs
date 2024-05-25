using UnityEngine;

namespace CreatureGrove
{
    public class Bullet : MonoBehaviour
    {

        private void OnCollisionEnter(Collision collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
               // enemy.TakeDamage(Gun.effectiveAtkPower());
            }
        }
    }
}
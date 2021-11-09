using UnityEngine;

namespace TaskTest.Fight
{

    public class Projectile : Weapon
    {
        [SerializeField] float force;
        private void Start()
        {
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
}

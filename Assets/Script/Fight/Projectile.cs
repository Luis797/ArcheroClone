using UnityEngine;

namespace TestTask.Fight
{

    public class Projectile : Weapon
    {
        [SerializeField] float force;
         //Time to destroy after the gameobject collides
        [SerializeField] float time;
        private void Start()
        {
            rb.velocity = transform.forward * force;
        }

        public new void OnTriggerEnter(Collider other) {
                base.OnTriggerEnter(other);
                Destroy(gameObject, time);
            
        }
        ///<summary>
        ///Reset the rigidbody velocity to zero.
        ///</summary>
        public override void ResetRigidBody()
        {       
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
        }

    }
}

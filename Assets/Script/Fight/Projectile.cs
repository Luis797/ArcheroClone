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
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
        }

        public new void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(objectTag.ToString())) return;
            ResetRigidBody();
            base.OnTriggerEnter(other);
            Destroy(gameObject, time);
        }

        ///<summary>
        ///Reset the rigidbody velocity to zero.
        ///</summary>
        private void ResetRigidBody()
        {       
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
        }

    }
}

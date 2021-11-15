using TestTask.Attribute;
using UnityEngine;

namespace TestTask.Fight
{
    public class AreaWeapon : Weapon
    {
        [SerializeField] float radius;
        [SerializeField] float force;
        //Time to destroy after the gameobject collides
        [SerializeField] float time;
        private void Start()
        {
            rb.velocity = transform.forward * force;
        }
        public override void ResetRigidBody()
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        public override void OnCollision(Attributes attribute)
        {
            Collider[] col= new Collider[15];
            //Add all the collider object information in the collider array
            int length = Physics.OverlapSphereNonAlloc(transform.position, radius,col);
            print(col.Length);
            for (int j = 0; j < length; j++)
            {
                Collider collider = col[j];
                if (collider != null && collider.CompareTag("Enemy"))
                {
                    //For all collider which is enemy deduct the damage
                    collider.GetComponent<Attributes>().TakeDamage(weponInfromation.damage);
                    Instantiate(weponInfromation.AfterEffectOnHit, col[j].transform.position, transform.rotation);
                }
            }
        }
    }
}
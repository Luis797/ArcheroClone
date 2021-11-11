using TestTask.Attribute;
using TestTask.Core;
using UnityEngine;

namespace TestTask.Fight
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Rigidbody rb;

        [Header("Effect to instantiate after hit to enemy")]
        [SerializeField] GameObject AfterEffectOnHit;
        [SerializeField] int damage;
        //Todo: May be do with layers
        [Header("Tag of the gameobject that this weapon is aimed at.")]

        [SerializeField] protected GameHandler.Tags enemyTag;

       
        [Header("Tag of the gameobject that instantiate this weapon.")]
        [SerializeField] protected GameHandler.Tags objectTag;

        public virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(objectTag.ToString())) return;
            ResetRigidBody();
            if (other.CompareTag(enemyTag.ToString()))
            {
                OnCollision(other.GetComponent<Attributes>());
            }
        }
        private void OnCollision(Attributes attribute)
        {
            attribute.TakeDamage(damage);
            Instantiate(AfterEffectOnHit, transform.position, transform.rotation);
        }
        public abstract void ResetRigidBody();
    }
}
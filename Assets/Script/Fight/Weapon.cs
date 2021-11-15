using TestTask.Attribute;
using TestTask.Core;
using UnityEngine;

namespace TestTask.Fight
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Rigidbody rb;
        [SerializeField] protected WeponInfromation weponInfromation;

        //Todo: May be do with layers
        [Header("Tag of the gameobject that this weapon is aimed at.")]

        [SerializeField] protected GameHandler.Tags enemyTag;


        public virtual void OnTriggerEnter(Collider other)
        {
            ResetRigidBody();
            if (other.CompareTag(enemyTag.ToString()))
            {
                OnCollision(other.GetComponent<Attributes>());
            }
        }
        public abstract void OnCollision(Attributes attribute);
       
        public abstract void ResetRigidBody();
    }
}
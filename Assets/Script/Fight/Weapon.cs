using TestTask.Core;
using UnityEngine;

namespace TaskTest.Fight{  
    public class Weapon : MonoBehaviour {
        [SerializeField]protected Rigidbody rb;

        [SerializeField] int damage;
        //Todo: May be do with layers
        [Header("Tag of the gameobject that this weapon is aimed at.")]

        [SerializeField]protected SharedMethods.Tags enemyTag;

       
        [Header("Tag of the gameobject that instantiate this weapon.")]
        [SerializeField]protected SharedMethods.Tags objectTag;
         //Time to destroy after the gameobject collides
        [SerializeField] float time;
         private void OnTriggerEnter(Collider other) {
             if(other.CompareTag(objectTag.ToString()))return;  
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Destroy(gameObject,time);
              if(other.CompareTag(enemyTag.ToString())){
				  OnCollision(other.GetComponent<Attributes>());    
          }
    }
        private void OnCollision(Attributes attribute)
        {
            attribute.TakeDamage(damage);       
        } 
    }
}
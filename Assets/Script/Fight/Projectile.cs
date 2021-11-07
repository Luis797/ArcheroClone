using UnityEngine;
using TestTask.Core;
namespace TestTask.Fight{
    
    public class Projectile : MonoBehaviour
    {
        //Time to destroy after the gameobject collides
        [SerializeField] float time;
        [SerializeField] Rigidbody rb;

        [SerializeField] float force;

        //Todo: May be do with layers
        [SerializeField] SharedMethods.Tags tags;

        //Direction to hit the enemy

        private void Start() 
        {
        Transform target;
        Vector3 shootDirection;
          target = SharedMethods.instance.FindClosetObject(transform,tags.ToString());    
          shootDirection = target.position - transform.position; 
          transform.rotation = Quaternion.LookRotation(shootDirection,transform.up);
            rb.AddForce(shootDirection * force,ForceMode.Impulse); 
        }
       
    private void OnTriggerEnter(Collider other) {
          if(other.CompareTag("Player"))return;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Destroy(gameObject,time);
    }  
    }
}

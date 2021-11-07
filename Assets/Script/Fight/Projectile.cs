using UnityEngine;
namespace TestTask.Fight{
    
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float time;
        Transform target;
        [SerializeField] Rigidbody rb;
        Vector3 shootDirection;

        private void Start() 
        {
          target = SharedMethods.instance.FindClosetObject(transform,"Enemy");    
          shootDirection = target.position - transform.position; 
          transform.rotation = Quaternion.LookRotation(shootDirection,transform.up);
            rb.AddForce(shootDirection * 10,ForceMode.Impulse); 
        }
       
    private void OnTriggerEnter(Collider other) {
        print(other.name);
          if(other.CompareTag("Player"))return;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
    }
      
    }
}

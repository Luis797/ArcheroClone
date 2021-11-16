using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestTask.UI;


namespace TestTask.Attribute
{
    public abstract class Attributes : MonoBehaviour
    {   
         float hp;
        [SerializeField]protected float mhp;

        [Header("Health bar script of the game object")]
        [SerializeField] HealthBar healthBar;

        [Header("Controller of the attached game object")]
        [SerializeField] Animator controller; 
        
        public virtual void Awake() {
            hp = mhp;
        }
        public void TakeDamage(int damage)
        {         
            hp -= damage;        
            IsDeath(hp);
            healthBar.UpdateHealthBar(hp,mhp);
            controller.SetTrigger("Damage");
        }
   
        ///<summary>
        ///Check if the player is death or not and do effect.
        ///</summary>
        protected abstract void IsDeath(float hp);
        public void IncreaseHealth(float health){
            hp+=health;
            //Heath cannot be more than max health point
            if(hp>mhp)
            hp=mhp;
            healthBar.UpdateHealthBar(hp,mhp);
        }

      
    }
}

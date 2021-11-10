using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestTask.UI;

namespace TestTask.Attribute
{
    public abstract class Attributes : MonoBehaviour
    {
        [SerializeField]public float hp;
        [SerializeField]public float mhp;

        [SerializeField] HealthBar healthBar;
        
        public virtual void Awake() {
            hp = mhp;
        }
        public void TakeDamage(int damage)
        {         
            hp -= damage;        
            IsDeath(hp);
            healthBar.UpdateHealthBar(hp,mhp);
        }

        
        ///<summary>
        ///Check if the player is death or not and do effect.
        ///</summary>
        protected abstract void IsDeath(float hp);
        public void IncreaseHealth(float health){
            hp+=health;
            healthBar.UpdateHealthBar(hp,mhp);
        }
    }
}

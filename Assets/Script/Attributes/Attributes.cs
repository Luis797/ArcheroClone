using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Attribute
{
    public abstract class Attributes : MonoBehaviour
    {
        [SerializeField] float hp;
        
        public void TakeDamage(int damage)
        {
            
            hp -= damage;        
            IsDeath(hp);
          
        }

        ///<summary>
        ///Check if the player is death or not and do effect.
        ///</summary>
        protected abstract void IsDeath(float hp);
        public void IncreaseHealth(float health){
            hp+=health;
        }
    }
}

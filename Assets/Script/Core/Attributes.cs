using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Core
{
    public abstract class Attributes : MonoBehaviour
    {
        [SerializeField] protected float hp;
        [SerializeField] protected float maxHp;

        protected void Awake()
        {
            hp = maxHp;
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                Death();
            }
        }
        protected abstract void Death();
    }
}

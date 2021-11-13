using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Fight
{

    public class TripleAttack : MonoBehaviour
    {
        [Header("Initialize single arrow here.")]
        [SerializeField] GameObject arrow;
        public void Start()
        {
            ThrowWeapons(transform.rotation, 30);
        }

        ///<summary>
        ///Throw arrow in different direction with one aiming towards player
        ///<summary>
        private void ThrowWeapons(Quaternion rotation, float angle)
        {
            Instantiate(arrow, transform.position, rotation * Quaternion.Euler(0, angle, 0));
            Instantiate(arrow, transform.position, rotation * Quaternion.Euler(0, -angle, 0));
        }
    }
}

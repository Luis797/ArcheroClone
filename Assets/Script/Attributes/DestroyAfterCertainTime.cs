using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Attribute
{
    public class DestroyAfterCertainTime : MonoBehaviour
    {
        [Header("Time to destroy the object after it is instantiate")]
        [SerializeField] float time;

        private void Awake()
        {
            Destroy(this.gameObject, time);
        }
    }
}


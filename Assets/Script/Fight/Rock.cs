using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Fight
{

    public class Rock : Weapon
    {
        private float gravity = Physics.gravity.y;
        private Vector3 targetPoint;

         private void Start()
        {
             rb.velocity = transform.forward * SpeedCalculate();
        }
        private float SpeedCalculate()
        {
            Vector3 fromTo = transform.forward - transform.position;
            Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);
            float x = fromToXZ.magnitude;
            float y = fromTo.y;
            float angleInRadians = 45 * Mathf.PI / 180;
            float speedSquare = (gravity * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
            return Mathf.Sqrt(Mathf.Abs(speedSquare)) + 10.0f;
        }
    }
}

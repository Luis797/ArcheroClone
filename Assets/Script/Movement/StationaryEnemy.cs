using System.Collections;
using UnityEngine;

namespace TestTask.Movement
{
    public class StationaryEnemy : Enemy
    {
        [Header("Game object to hit toward player")]
        [SerializeField] GameObject arrow;
        public override void EnemyAttack()
        {
            StartCoroutine(ThrowWeapons(transform.rotation,30));          
        }

        ///<summary>
        ///Throw arrow in different direction with one aiming towards player
        ///<summary>
        IEnumerator ThrowWeapons(Quaternion rotation,float angle)
        {   
            yield return new WaitForSeconds(1f);
            Instantiate(arrow, transform.position, rotation);
            Instantiate(arrow, transform.position, rotation * Quaternion.Euler(0, angle, 0));
            Instantiate(arrow, transform.position, rotation * Quaternion.Euler(0, -angle, 0));
        }
    }
}

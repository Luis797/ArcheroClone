using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TestTask.Core;
using UnityEngine;
using UnityEngine.AI;

namespace TestTask.Movement
{

    public class FlyingEnemy : Attributes
    {

        //Time to remain stationary before another flight
        float stationaryTime;
        Transform player;
        protected new void Awake()
        {
            base.Awake();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            stationaryTime = Random.Range(1, 10f);

        }
        protected override void Death()
        {
            Destroy(this.gameObject);
        }

        private void Update()
        {

            if (stationaryTime < 0)
            {
                transform.DOMove(player.position, 1f);
                stationaryTime = Random.Range(3, 6);
            }
            else
            {
                stationaryTime -= Time.deltaTime;
            }
        }
    }
}

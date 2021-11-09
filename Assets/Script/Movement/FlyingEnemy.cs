using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TestTask.Attribute;
using TestTask.Core;
using UnityEngine;


namespace TestTask.Movement
{

    public class FlyingEnemy : Attributes
    {

        [Header("Reward object for player after player death.")]
        [SerializeField] GameObject coins;
        //Time to remain stationary before another flight
        float stationaryTime;
        Transform player;
        protected void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            stationaryTime = Random.Range(1, 10f);

        }
        protected override void IsDeath(float hp)
        {
            if (hp <= 0)
            {
                Instantiate(coins,transform.position,transform.rotation);
                GameHandler.instance.RemoveEnemy(this.transform);
                Destroy(this.gameObject);
            }
            DOTween.Kill(this.gameObject);
        }

        private void Update()
        {

            if (stationaryTime < 0)
            {
                if(transform!=null)
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

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TestTask.Attribute;
using TestTask.Core;
using UnityEngine;


namespace TestTask.Movement
{

    public abstract class Enemy : Attributes
    {

        [Header("Reward object for player after player death.")]
        [SerializeField] GameObject coins;
        //Time to remain stationary before another flight
        float stationaryTime;

        float walkingTime;


        protected Transform player;
        protected new void Awake()
        {
            base.Awake();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            stationaryTime = Random.Range(1, 10f);

        }
        protected override void IsDeath(float hp)
        {
            //Todo: Determine how to remove the DOTween effects
            transform.DOKill(false);
            if (hp <= 0)
            {
                GameHandler.instance.RemoveEnemy(this.transform);
                //Instantiate the coin/gems/diamond to the position after enemy death
                InstantiateSomeCoins();
                //gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }

        private void InstantiateSomeCoins()

        {
            for (int i = 0; i < Random.Range(2, 5); i++)
                //Randomly instantiate the coins near player
                Instantiate(coins, transform.position + transform.forward * Random.Range(-1, 1f) 
                + transform.right * Random.Range(-1, 1f), coins.transform.rotation);
        }

        private void Update()
        {
            transform.LookAt(player.position);
            if (stationaryTime < 0)
            {
                EnemyAttack();
                stationaryTime = Random.Range(3, 6);
            }
            else
            {
                stationaryTime -= Time.deltaTime;
            }
        }

        public abstract void EnemyAttack();
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BrokenVector.LowPolyFencePack;

namespace TestTask.Core{    
    public class CoinCollect : MonoBehaviour {

        List<GameObject> coinCollection = new List<GameObject>();
        Transform player;

        [Header("Attach the door controller script of the game")]
        [SerializeField] DoorController doorController;

        private void Start() {
            //Register the event to the coin Drop
            CoinDrop.OnCoinDrop+=OnCoinDrop;
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
       private void OnCoinDrop(GameObject coin){
           coinCollection.Add(coin);
            if(!GameHandler.instance.EnemyExits())
                CollectAchievement();
       }

        private void OnDestroy() {
             //Removing the registered event to the coin Drop
            CoinDrop.OnCoinDrop -= OnCoinDrop;
        }

        ///<summary>
        ///Call once the game is completed.
        ///</summary>
        private void CollectAchievement()
        {
            Invoke(nameof(CollectCoins),1f);
        }

        ///<summary>
        ///Collect the coins once all the enemy is dead after certain time.
        ///</summary>
        private void CollectCoins(){
            GameHandler.instance.IncreaseXP(coinCollection.Count);
             foreach(GameObject coin in coinCollection){
                coin.transform.DOMove(player.position,0.2f);
                Destroy(coin,0.55f);
                doorController.OpenDoor();
            }
            ///Once the animation is done clear the list for next round
            coinCollection.Clear();
        }
    }
}
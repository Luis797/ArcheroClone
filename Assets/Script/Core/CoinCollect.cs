using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BrokenVector.LowPolyFencePack;

namespace TestTask.Core{    
    public class CoinCollect : MonoBehaviour {

        List<GameObject> coinCollection = new List<GameObject>();
        Transform player;
        [SerializeField] DoorController doorController;

        private void Start() {
            CoinDrop.OnCoinDrop+=OnCoinDrop;
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
       private void OnCoinDrop(GameObject coin){
           coinCollection.Add(coin);
            if(!GameHandler.instance.EnemyExits())
                CollectAchievement();
       }


        ///<summary>
        ///Call once the game is completed.
        ///</summary>
        private void CollectAchievement()
        {
            GameHandler.instance.Level++;
            Invoke(nameof(CollectCoins),1f);
        }

        ///<summary>
        ///Collect the coins once all the enemy is dead after certain time.
        ///</summary>
        private void CollectCoins(){
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
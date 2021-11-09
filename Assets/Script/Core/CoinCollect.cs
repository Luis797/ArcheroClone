using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TestTask.Core{    
    public class CoinCollect : MonoBehaviour {

      public List<GameObject> coinCollection = new List<GameObject>();
        Transform player;
        private void Start() {
            CoinDrop.OnCoinDrop+=OnCoinDrop;
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
       private void OnCoinDrop(GameObject coin){
           coinCollection.Add(coin);
           print(GameObject.FindGameObjectsWithTag("Enemy").Length );
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                CollectAchievement();
       }

        private void CollectAchievement()
        {
            foreach(GameObject coin in coinCollection){
                coin.transform.DOMove(player.position,0.5f);
                Destroy(coin,0.55f);

            }
        }
    }
}
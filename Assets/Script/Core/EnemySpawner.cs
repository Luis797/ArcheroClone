using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Core
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Enemy spawn variables")]
        [SerializeField] private int enemyCount;
        [SerializeField] private List<GameObject> enemies;

        [Header("These are the transform in game that defines the range within which the enemy can spawn")]
        [SerializeField] Transform lowestPoint, highestPoint;

        
        ///<summary>
        ///Instantiate enemy according to level
        ///</summary>
        public void SpawnEnemy(int level)
        {
            ///Todo : The level information should be used to instantiate the enemy
            if (enemies.Count < 1) return;

            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = enemies[UnityEngine.Random.Range(0, enemies.Count)];
                GameHandler.instance.AddEnemy(Instantiate(enemy, InstantiatePosition(), enemy.transform.rotation).transform);
            }
        }

        private Vector3 InstantiatePosition()
        {
            //Todo: Make sure the enemies doesnot collide with each other
            return new Vector3(UnityEngine.Random.Range(lowestPoint.position.x, highestPoint.position.x), 0.5f, UnityEngine.Random.Range(lowestPoint.position.z, highestPoint.position.z));
        }
    }
}

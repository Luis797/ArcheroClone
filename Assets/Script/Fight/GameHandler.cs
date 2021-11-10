using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask.Core
{
    public class GameHandler : MonoBehaviour
    {
        public static GameHandler instance;

        Vector3 playerInitialPosition;

        [SerializeField] Transform player;
        [SerializeField] Text levelText;

        private int level = 1;

        private List<Transform> enemies = new List<Transform>();

        [SerializeField] EnemySpawner enemySpawner;

        public int Level{
            get{
                return level;
            }
            set{
                level = value;
            }
        }
        public enum Tags
        {
            Enemy, Player
        }


         void Awake()
        {
            if (instance != null)
                Destroy(this.gameObject);
            instance = this;
            enemySpawner.SpawnEnemy(level);
            playerInitialPosition = player.position;
        }


        ///<summary>
        ///Helps determine if any enemy exits
        ///</summary>
        public bool EnemyExits(){
            return (enemies.Count>0);
        }

        public void AddEnemy(Transform enemy)
        {
            enemies.Add(enemy);
        }

        /// <summary>
        /// Removes enemy from enemies list, if list is empty level passed
        /// </summary>
        /// <param name="enemy"></param>
        public void RemoveEnemy(Transform enemy)
        {
            enemies.Remove(enemy);
        }

        ///<summary>
        ///Determine the closet Enemy from player.
        ///</summary>
        public Transform FindClosetEnemy(Transform callingObject)
        {
            if(enemies.Count == 0) return null;
            float closetDistance = Mathf.Infinity;
            Transform closetObject = null;
            foreach (Transform enemy in enemies)
            {
                float distance = Vector3.Distance(callingObject.position, enemy.transform.position);
                if (closetDistance > distance)
                {
                    closetDistance = distance;
                    closetObject = enemy;
                }
            }
            return closetObject;
        }

        public void ResetGame(){
            enemySpawner.SpawnEnemy(level);
            player.position = playerInitialPosition;
            levelText.text = "Level "+ level;
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Core
{
    public class GameHandler : MonoBehaviour
    {
        public static GameHandler instance;
        public enum Tags
        {
            Enemy, Player
        }
        [SerializeField] private List<Transform> enemies;

         void Awake()
        {
            if (instance != null)
                Destroy(this.gameObject);
            instance = this;
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
            if (enemies.Count == 0)
            {

            }
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
    }

}
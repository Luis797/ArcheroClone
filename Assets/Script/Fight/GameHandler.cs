using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TestTask.Helper;
namespace TestTask.Core
{
    public class GameHandler : MonoBehaviour
    {
        public static GameHandler instance;

        Vector3 playerInitialPosition;

        [SerializeField] Transform player;

        [Header("Level text of top of the UI")]
        [SerializeField] Text levelText;
        
        [Header("Slider that defines XP")]
        [SerializeField] Slider xpSlider;

        private LevelSystem levelSystem = new LevelSystem();

        private List<Transform> enemies = new List<Transform>();

        private int GameLevel;
        [SerializeField] EnemySpawner enemySpawner;
        public enum Tags
        {
            Enemy, Player
        }

         void Awake()
        {
            if (instance != null)
                Destroy(this.gameObject);
            instance = this;
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
            enemySpawner.SpawnEnemy(GameLevel);
            player.position = playerInitialPosition;
        }

        ///<summary>
        ///Increase the XP of the player.
        ///</summary>
        public void IncreaseXP(int coinCollected){
           levelSystem.AddXp(coinCollected);
           xpSlider.value = levelSystem.GetXPNormaized();
           levelText.text = "Level "+ levelSystem.Level();
           GameLevel ++;
        }
    }

}
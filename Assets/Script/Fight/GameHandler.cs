using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TestTask.Helper;
using System;
using TestTask.Attribute;

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

        [SerializeField] PlayerInformation playerInformation;


        private LevelSystem levelSystem = new LevelSystem();

        private List<Transform> enemies = new List<Transform>();

        private int GameLevel;
        [SerializeField] EnemySpawner enemySpawner;

        //Assign reward system to activate when level increases.
        [SerializeField] GameObject rewardSystem;

        [Header("Canvas gameobject that is activate on pause")]
        [SerializeField] GameObject pauseMenu;

        [Header("TextMesh within environment")]
        [SerializeField] TextMesh levelTextMesh;

        bool gameOver = false;
        

        public bool isPause = false;
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
            //Suscribe to the event
            levelSystem.OnLevelUpdate += LevelSystem_OnLevelUpdate;
        }

        private void LevelSystem_OnLevelUpdate()
        {
           Invoke(nameof(RewardUnlock),0.5f);
        }

        private void RewardUnlock()
        {
            rewardSystem.SetActive(true);
        }

        private void Update() {
            if(gameOver) return;
            if(Input.GetKeyDown(KeyCode.Escape)){
                isPause =!isPause;
                PauseGame(isPause);
            }
        }

        private void OnDestroy() {
            Time.timeScale = 1f;
        }
        private void PauseGame(bool isPause)
        {
           pauseMenu.SetActive(isPause);
           Time.timeScale = isPause?0:1;
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

        public void NextLevelGame(){
            enemySpawner.SpawnEnemy(GameLevel);
            player.position = playerInitialPosition;
            GameLevel ++;
            levelTextMesh.text = GameLevel.ToString();
        }

        ///<summary>
        ///Increase the XP of the player.
        ///</summary>
        public void IncreaseXP(int coinCollected){
           levelSystem.AddXp(coinCollected);
           playerInformation.SaveJsonData(playerInformation.Coins()+coinCollected);
           xpSlider.value = levelSystem.GetXPNormaized();
           levelText.text = "Level "+ levelSystem.Level();
        }


        public void GameOver(){
            gameOver = true;
            PauseGame(true);
        }
    }

}
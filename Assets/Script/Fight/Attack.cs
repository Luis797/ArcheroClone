using System;
using DG.Tweening;
using TestTask.Attribute;
using TestTask.Core;
using TestTask.Helper;
using UnityEngine;

namespace TestTask.Fight
{
    public class Attack : Attributes, IBehaviour
    {
        [Header("Defines the time between attack")]

        [SerializeField] float timeBetweenAttacks;

        [Header("Add player behaviour scriptable object")]

        [SerializeField] PlayerInformation playerInformation;

        [Header("Point of launch of weapon")]
        [SerializeField] Transform pointOfLaunch;


        PlayerBehaviour playerBehaviour;
        float tempTime;
        bool canAttack = false;
         [SerializeField] RewardSystem rewardSystem;

        PlayerSkill playerSkill;

        public new  void Awake() { 
            base.Awake();
            playerSkill = new PlayerSkill();
            rewardSystem.SetPlayerSkill(playerSkill);
            playerSkill.OnSkillUnLocked += PlayerSkill_OnSkillUnLocked;
        }

        // Todo : According to the object choose by player change the player states like weapon, health.
        private void PlayerSkill_OnSkillUnLocked(PlayerSkill.OnSkillUnlock e)
        {
            print(e.skillType);
            switch(e.skillType){
                case PlayerSkill.SkillType.HeadShot:
                break;
                case PlayerSkill.SkillType.Heal:
                IncreaseHealth(mhp);
                break;        
            }
        }

        private void Start()
        {
            tempTime = timeBetweenAttacks;
            playerBehaviour = GetComponent<PlayerBehaviour>();
        }
        private void Update()
        {
            if (!canAttack) return;
            tempTime -= Time.deltaTime;
            if (tempTime <= 0)
            {
                AttackEnemy();
            }
        }

        ///<summary>
        ///Attack the enemy
        ///</summary>
        private void AttackEnemy()
        {
            LookTowardsEnemy();
            tempTime = timeBetweenAttacks;
            Instantiate(playerInformation.weapon, pointOfLaunch.position, pointOfLaunch.rotation);
        }


        ///<summary>
        ///Make the player looks towards the enemy during attack
        ///</summary>
        private void LookTowardsEnemy()
        {
            Transform enemy = GameHandler.instance.FindClosetEnemy(transform);
            if (enemy == null)
            {
                canAttack = false;
                return;
            }
            Vector3 position = enemy.position;
            transform.DOLookAt(position, 0.2f);
        }

        ///<summary>
        ///let player attack enemy
        ///</summary>
        public void SetCanAttack(Transform enemy)
        {
            LookTowardsEnemy();
            playerBehaviour.ChangeBehaviour(this);
            canAttack = true;
        }
        public void CancelBehavior()
        {
            canAttack = false;
        }
         protected override void IsDeath(float hp)
        {
            if (hp <= 0)
            {
                GameHandler.instance.GameOver();
            }
        }
    }
}
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
        [SerializeField] float timeBetweenAttacks;

        //Todo:Place this somewhere for more convinent with instantiating and upgrading the weapons.
        [SerializeField] GameObject weapon;

        [SerializeField] GameHandler.Tags tags;


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

        // Todo : According to the object choose by player change the player states like weapon health
        private void PlayerSkill_OnSkillUnLocked(object sender, PlayerSkill.OnSkillUnlock e)
        {
            switch(e.skillType){
                case PlayerSkill.SkillType.headShot:
                break;
                case PlayerSkill.SkillType.heal:
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

        private void AttackEnemy()
        {
            LookTowardsEnemy();
            tempTime = timeBetweenAttacks;
            Instantiate(weapon, pointOfLaunch.position, pointOfLaunch.rotation);
        }


        ///<summary>
        ///Make the player looks towards the enemy during attack
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
                print("Death");
            }
        }
    }
}
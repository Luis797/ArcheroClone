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

        [Header("Add reward system from within the scene to assign playerskill class")]
        [SerializeField] RewardSystem rewardSystem;

        [Header("Add area weapon here")]
        [SerializeField] GameObject areaWeapon;
        [Header("Add triple shot weapon here")]
        [SerializeField] GameObject tripleShotWeapon;

        PlayerSkill playerSkill;
        PlayerBehaviour playerBehaviour;
        float tempTime;
        bool canAttack = false;
        GameObject weapon;

        public new void Awake()
        {
            base.Awake();
            playerSkill = new PlayerSkill();
            rewardSystem.SetPlayerSkill(playerSkill);
            playerSkill.OnSkillUnLocked += PlayerSkill_OnSkillUnLocked;
            weapon = playerInformation.weapon;
        }

        // Todo : According to the object choose by player change the player states like weapon, health.
        private void PlayerSkill_OnSkillUnLocked(PlayerSkill.OnSkillUnlock e)
        {
            print(e.skillType);
            switch (e.skillType)
            {
                case PlayerSkill.SkillType.AreaAttack:
                    weapon = areaWeapon;
                    break;
                case PlayerSkill.SkillType.TripleShot:
                    weapon = tripleShotWeapon;
                    break;
                case PlayerSkill.SkillType.Heal:
                    IncreaseHealth(mhp);
                    break;
                case PlayerSkill.SkillType.IncreaseSpeed:
                    playerInformation.speed += 1.5f;
                    break;
                     case PlayerSkill.SkillType.AttackRate:
                    timeBetweenAttacks = 0.75f;
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
            Instantiate(weapon, pointOfLaunch.position, pointOfLaunch.rotation);
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
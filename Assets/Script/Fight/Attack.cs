using System;
using DG.Tweening;
using TestTask.Core;
using UnityEngine;

namespace TestTask.Fight
{
    public class Attack : MonoBehaviour, IBehaviour
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
    }
}
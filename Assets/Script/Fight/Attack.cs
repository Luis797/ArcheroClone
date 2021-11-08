using System;
using DG.Tweening;
using TestTask.Core;
using UnityEngine;

namespace TestTask.Fight{    
    public class Attack : MonoBehaviour,IBehaviour {
        [SerializeField] float timeBetweenAttacks;

        //Todo:Place this somewhere for more convinent with instantiating and upgrading the weapons.
        [SerializeField] GameObject weapon;

        [SerializeField] SharedMethods.Tags tags;

        PlayerBehaviour playerBehaviour;
        float tempTime;
        bool canAttack = false;

        private void Start() {
            tempTime = timeBetweenAttacks;
            playerBehaviour = GetComponent<PlayerBehaviour>();
        }
        private void Update() {
            if(!canAttack) return;
            tempTime -=Time.deltaTime;
            if(tempTime <=0){
                AttackEnemy();
            }
        }

        private void AttackEnemy(){
            LookTowardsEnemy();
            tempTime = timeBetweenAttacks;       
            Instantiate(weapon,transform.position,transform.rotation);
        }

        private void LookTowardsEnemy()
        {
            Transform enemy = SharedMethods.instance.FindClosetObject(transform,tags.ToString());
            if(enemy==null){
                canAttack = false;
              return;
              }
            transform.DOLookAt(enemy.position,0.2f);
        }

        public void SetCanAttack(Transform enemy){
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
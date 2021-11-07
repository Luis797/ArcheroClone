using TestTask.Core;
using UnityEngine;

namespace TestTask.Fight{    
    public class Attack : MonoBehaviour,IBehaviour {
        [SerializeField] float timeBetweenAttacks;

        //Todo:Place this somewhere for more convinent with instantiating and upgrading the weapons.
        [SerializeField] GameObject weapon;

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
            tempTime = timeBetweenAttacks;       
            Instantiate(weapon,transform.position,weapon.transform.rotation);
        }

        public void SetCanAttack(){
            playerBehaviour.ChangeBehaviour(this);
            if(GameObject.FindGameObjectsWithTag("Enemy").Length!=0)
            canAttack = true;
        }
        public void CancelBehavior()
        {
           canAttack = false;
        }
    }
}
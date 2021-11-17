using System.Collections;
using System.Collections.Generic;
using TestTask.Core;
using UnityEngine;
using TestTask.Attribute;
namespace TestTask.Movement
{
    public class PlayerMovement : Movement
    {
        [SerializeField] PlayerInformation playerInformation;
        bool setAttack = false;
        float speed;
        private new void Awake() {
            base.Awake();
           speed = playerInformation.speed; 
        }

        private void OnDestroy() {
            playerInformation.speed = speed;
        }
        private void Update()
        {
            if(GameHandler.instance.isPause) return;
            if (Input.anyKey)
                Move();
            else if (!setAttack)
            {
                setAttack = true;
                if (GameHandler.instance.EnemyExits())
                    attack.SetCanAttack(enemy);
            }
        }
        ///<summary>
        ///Control the player with the use of arrow key.
        ///</summary>
        void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            //Determine if the player is pressing the WASD or ARROW key
            if (horizontal == 0f && vertical == 0f)
            {
                return;
            }
            setAttack = false;
            CollisionCheck();
            behaviour.ChangeBehaviour(this);
            float perFrameTime = Time.deltaTime;
            Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
            //Move player by speed value every franme
            transform.position = transform.position + moveDirection * perFrameTime * playerInformation.speed;
            //Look towards the move direction
            transform.rotation = LookAtDirection(animationMesh.rotation, moveDirection);
        }
    }

}

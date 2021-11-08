using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Movement{
    public class PlayerMovement : Movement{

        bool setAttack = false;

        [Header("Speed at which player moves.")]
        [SerializeField] float speed;

         private void Update()
        {
            if(Input.anyKey)
                Move();
            else if (!setAttack){
                setAttack = true;
                //Todo: Implement better way to identify if enemy exits
            if(GameObject.FindGameObjectsWithTag("Enemy").Length!=0)
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
            if(horizontal == 0f && vertical == 0f)
                return;
                setAttack = false;
            CollisionCheck();
            
            behaviour.ChangeBehaviour(this);
            float perFrameTime = Time.deltaTime;
            Vector3 moveDirection = new Vector3(horizontal,0,vertical);
            //Move our player by our speed every france
            transform.position = transform.position + moveDirection * perFrameTime *speed;
            transform.rotation = LookAtDirection(animationMesh.rotation, moveDirection);
        }
    }

}

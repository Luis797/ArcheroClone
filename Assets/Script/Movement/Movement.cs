using TestTask.Core;
using TestTask.Fight;
using UnityEngine;

namespace TestTask.Movement{
    public class Movement : MonoBehaviour,IBehaviour
    {
        [SerializeField] float speed;
        PlayerBehaviour behaviour;
        Attack attack;
        bool setAttack = false;
        private void Awake() {
            behaviour = GetComponent<PlayerBehaviour>();
            attack = GetComponent<Attack>();
        }
        private void Update()
        {
            if(Input.anyKey)
                PlayerMovement();
            else if (!setAttack){
                setAttack = true;
               attack.SetCanAttack();
            }
        }


        ///<summary>
        ///To control the player with the use of arrow key.
        ///</summary>
        private void PlayerMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if(horizontal == 0f && vertical == 0f)
                return;
                setAttack = false;
            behaviour.ChangeBehaviour(this);
            float perFrameTime = Time.deltaTime;
            transform.position = transform.position + transform.forward * vertical * perFrameTime *speed
            + transform.right * horizontal * perFrameTime * speed;
        }

        public void CancelBehavior()
        {
            
        }
    }

}
using UnityEngine;

namespace TestTask.Core
{
    public class PlayerBehaviour : MonoBehaviour
    {
        IBehaviour behaviour;
        public void ChangeBehaviour(IBehaviour behaviour)
        {
            if (this.behaviour == behaviour) return;
            if (this.behaviour != null)
                this.behaviour.CancelBehavior();
            this.behaviour = behaviour;

        }
    }
}

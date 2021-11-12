using UnityEngine;

namespace TestTask.Core
{
    public class CameraControl : MonoBehaviour
    {
        [Header("Attach the player component.")]
        [SerializeField] Transform player;

        [Header("Height of camera from the players position.")]
        [SerializeField] float offsetZ;
        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + offsetZ);
        }
    }
}


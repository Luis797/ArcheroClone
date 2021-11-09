using UnityEngine;

namespace TestTask.Core
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] float offsetZ;
        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + offsetZ);
        }
    }
}


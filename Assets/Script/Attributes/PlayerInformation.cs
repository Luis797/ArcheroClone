using UnityEngine;

namespace TestTask.Attribute
{

    [CreateAssetMenu(fileName = "PlayerInformation", menuName = "TestTask/PlayerInformation", order = 0)]
    public class PlayerInformation : ItemInformation
    {
        [Header("Add the weapon of the player")]
        public GameObject weapon;

        [Header("Speed at which player moves.")]
        public float speed;
      
       
    }
}
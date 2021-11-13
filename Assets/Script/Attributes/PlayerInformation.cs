using UnityEngine;

namespace TestTask.Attribute
{

    [CreateAssetMenu(fileName = "PlayerInformation", menuName = "TestTask/PlayerInformation", order = 0)]
    public class PlayerInformation : ScriptableObject
    {
        [Header("Add the weapon of the player")]
        public GameObject weapon;

        [HideInInspector]
        public int CoinCollected = 0;

    }
}
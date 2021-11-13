    using UnityEngine;

namespace TestTask.Attribute{    
    [CreateAssetMenu(fileName = "SkinInfromation", menuName = "TestTask/SkinInfromation", order = 0)]
    public class SkinInfromation : ScriptableObject {
        [Header("Color of the material")]
        public Color color;
        [Header("Coin required to buy the weapon")]
        public int coinRequired = 50;

        [Header("Defines if the weapon is available for the player")]

        public bool bought = false;
        
    }
}
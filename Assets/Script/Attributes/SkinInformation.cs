    using UnityEngine;

namespace TestTask.Attribute{    
    [CreateAssetMenu(fileName = "SkinInfromation", menuName = "TestTask/SkinInfromation", order = 0)]
    public class SkinInformation : ScriptableObject {
        [Header("Color of the material")]
        public Color color;
        [Header("Coin required to buy the weapon")]
        public int coinRequired = 50;
    }
}
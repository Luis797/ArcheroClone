using TestTask.Saving;
using UnityEngine;

namespace TestTask.Attribute{    
    [CreateAssetMenu(fileName = "SkinInfromation", menuName = "TestTask/SkinInfromation", order = 0)]
    public class SkinInformation : ItemInformation {
        [Header("Color of the material")]
        public Color color;       
    }
}
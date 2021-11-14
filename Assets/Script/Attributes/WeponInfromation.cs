using TestTask.Saving;
using UnityEngine;

namespace TestTask.Attribute{    
    [CreateAssetMenu(fileName = "WeponInfromation", menuName = "TestTask/WeponInfromation", order = 0)]
    public class WeponInfromation : ItemInformation,ISaveable {
        
        [Header("Damage done by the weapon")]
        public int damage = 5;
        [Header("Effect to instantiate after hit to enemy")]
        public GameObject AfterEffectOnHit;             
    }
}
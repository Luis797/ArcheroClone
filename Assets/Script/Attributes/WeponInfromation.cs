    using UnityEngine;

namespace TestTask.Attribute{    
    [CreateAssetMenu(fileName = "WeponInfromation", menuName = "TestTask/WeponInfromation", order = 0)]
    public class WeponInfromation : ScriptableObject {
        
        [Header("Damage done by the weapon")]
        public int damage = 5;
        [Header("Effect to instantiate after hit to enemy")]
        public GameObject AfterEffectOnHit;
        
        [Header("Coin required to buy the weapon")]
        public int coinRequired = 50;

        [Header("Defines if the weapon is available for the player")]

        public bool bought = false;
        
    }
}
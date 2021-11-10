using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] Image bar;

        ///<summary>
        ///Update the health bar of the atrribute
        ///</summary>
        public void UpdateHealthBar(float hp,float mhp)
        {
            bar.fillAmount =  hp / mhp;
        }

    }
}


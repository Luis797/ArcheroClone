using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TestTask.Core
{
    public class CoinDrop : MonoBehaviour
    {
        public static event Action<GameObject> OnCoinDrop;
        private void Awake()
        {
            if (OnCoinDrop != null)
                OnCoinDrop(this.gameObject);
        }
    }
}

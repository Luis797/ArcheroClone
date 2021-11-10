using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrokenVector.LowPolyFencePack;
namespace TestTask.Core
{
    public class LoadNextLevel : MonoBehaviour
    {
        [SerializeField] DoorController doorController;

        private void OnTriggerEnter(Collider other) {
            if(other.CompareTag("Player") && doorController.IsDoorOpen ){
              GameHandler.instance.ResetGame();          
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrokenVector.LowPolyFencePack;
namespace TestTask.Core
{
    public class LoadNextLevel : MonoBehaviour
    {
        [SerializeField] DoorController doorController;

        [Header("Swipe effect panel.")]
        [SerializeField] GameObject swipeEffect;
        private void OnTriggerEnter(Collider other) {
            if(other.CompareTag("Player") && doorController.IsDoorOpen ){
                doorController.CloseDoor();
              GameHandler.instance.NextLevelGame();  
              swipeEffect.SetActive(true);        
            }
        }
    }
}

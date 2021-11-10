using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestTask.UI
{
    public class MenuManager : MonoBehaviour
    {
        public void LoadLevel(){
            SceneManager.LoadScene(1);
        }

        public void Quit(){
            Application.Quit();
        }
    }
}


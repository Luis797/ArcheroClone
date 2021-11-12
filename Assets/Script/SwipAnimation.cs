using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipAnimation : MonoBehaviour
{
    [SerializeField] float totalTime;
    float tempTime;
    [SerializeField] Image splashImage;
    private void OnEnable()
    {
        tempTime = totalTime;
    }


    // Update is called once per frame
    void Update()
    {
        if (tempTime > 0)
            {
                tempTime -=Time.deltaTime;
              //  splashImage.fillAmount = tempTime/totalTime;
            }else{
                gameObject.SetActive(false);
            }
    }
}

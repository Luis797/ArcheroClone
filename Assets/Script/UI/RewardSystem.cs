using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardSystem : MonoBehaviour
{
    List<List<string>> rewardsTitle  = new List<List<string>>();
   
    [SerializeField] Text[] rewards;
    [SerializeField] float time;
    float tempTIme = 0;
    
    // class Reward{

    // }
    private void Start() {
        Invoke(nameof(DeactivateScript),3f);
    }

    private void DeactivateScript()
    {
        this.enabled = false;
    }
    
    void ShowRewards()
    {     
       for(int i =0;i< rewardsTitle.Count;i++)
            rewards[i].text = rewardsTitle[i][Random.Range(0, rewardsTitle.Count)];          
    }
    // Update is called once per frame
    void Update()
    {
     if(tempTIme<time)
        {
            tempTIme += Time.deltaTime;
        }
        else
        {
            tempTIme = 0;
            ShowRewards();
        }
    }
}

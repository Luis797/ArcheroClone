using System.Collections;
using System.Collections.Generic;
using TestTask.Helper;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class RewardSystem : MonoBehaviour
{
    //Holds the name of the reward the user can choose
    public List<string> rewardsTitle = new List<string>();

    //All three rewards text in the UI
    [SerializeField] Text[] rewards;

    List<string> rewardChoice = new List<string>();

    [Header("Amount of time between each change in name ")]
    [SerializeField] float time;
    float tempTIme = 0;

    //When true will only allow user to choose the reward
    bool selectReward = false;
    PlayerSkill playerSkill;
    
    private void Start()
    {
        Invoke(nameof(DeactivateScroll), 3f);
        //Converting the skilltype enum to list.
        rewardsTitle = Enum.GetNames(typeof(PlayerSkill.SkillType)).ToList();
    }

    public void UnlockSkill()
    {
        if(!selectReward)return;
        //todo : Identify the method to trasfer the reward enum.
        playerSkill.UnlockSkill(PlayerSkill.SkillType.Heal);
     gameObject.SetActive(false);
    }

    public void SetPlayerSkill(PlayerSkill playerSkill)
    {
        this.playerSkill = playerSkill;
    }
    private void DeactivateScroll()
    {
        selectReward = true;
    }

    void ShowRewards()
    {
         List<string> reward = rewardsTitle.ToList();
        for (int i = 0; i < rewards.Length; i++){
            String currentReward =  reward[UnityEngine.Random.Range(0, reward.Count)];
            rewards[i].text = currentReward;
            //Remove the item so that the next choice doesnot consist same reward
            reward.Remove(currentReward);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (selectReward) return;
        if (tempTIme < time)
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

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
    List<PlayerSkill.SkillType> skill = new List<PlayerSkill.SkillType>();
    PlayerSkill.SkillType[] selectedSkill = new PlayerSkill.SkillType[3];

    GameObject[] weapons = new GameObject[3];
    private void Start()
    {
        Invoke(nameof(DeactivateScroll), 3f);
        //Converting the skilltype enum's name to list.
        rewardsTitle = Enum.GetNames(typeof(PlayerSkill.SkillType)).ToList();
        //Converting the skilltype enum to list.
        skill = Enum.GetValues(typeof(PlayerSkill.SkillType)).Cast<PlayerSkill.SkillType>().ToList();
    }

    public void UnlockSkill(int i)
    {
        if(!selectReward)return;
        //Method to trasfer the reward enum.
        playerSkill.UnlockSkill(selectedSkill[i]);
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

    ///<summary>
    ///Define different skills for each entity(canvas) and store the value to be derived later
    ///</summary>
    void ShowRewards()
    {
         List<string> reward = rewardsTitle.ToList();
         List<PlayerSkill.SkillType> skills = skill.ToList();
        for (int i = 0; i < rewards.Length; i++){
            int randomIntWithinRange = UnityEngine.Random.Range(0, reward.Count);
            String currentReward =  reward[randomIntWithinRange];
            rewards[i].text = currentReward;
            selectedSkill[i] = skills[randomIntWithinRange];
            //Remove the item so that the next choice doesnot consist same reward
            reward.Remove(currentReward);
            //Remove the skill to match corresponding reward item
            skills.Remove(skills[randomIntWithinRange]);
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

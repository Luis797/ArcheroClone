using TestTask.Fight;
using TestTask.Helper;
using TestTask.Attribute;
using UnityEngine;

[CreateAssetMenu(fileName = "HandleHealing", menuName = "TestTask/HandleHealing", order = 0)]
public class HandleHealing : ScriptableObject {

     public void ChangeHealth(Attack attack, PlayerSkill.SkillType e,PlayerInformation playerInformation){
       
        switch(e){
            case PlayerSkill.SkillType.Heal:
           attack.IncreaseHealth(25f);
            break;
           
            
        }
    }
}
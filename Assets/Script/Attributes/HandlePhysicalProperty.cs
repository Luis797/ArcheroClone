using TestTask.Fight;
using TestTask.Helper;
using TestTask.Attribute;
using UnityEngine;

[CreateAssetMenu(fileName = "HandlePhysicalProperty", menuName = "TestTask/HandlePhysicalProperty", order = 0)]
public class HandlePhysicalProperty : ScriptableObject
{
    public void ChangePhysicalProperty(Attack attack, PlayerSkill.SkillType e,PlayerInformation playerInformation)
    {
        switch (e)
        {
            case PlayerSkill.SkillType.IncreaseSpeed:
                playerInformation.speed = 0.75f;
                break;
            case PlayerSkill.SkillType.AttackRate:
                attack.ChangeTimeBetweenAttack(0.05f);
                break;
        }
    }
}
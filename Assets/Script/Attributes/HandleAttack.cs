using UnityEngine;
using TestTask.Helper;

[CreateAssetMenu(fileName = "HandleAttack", menuName = "TestTask/HandleAttack", order = 0)]
public class HandleAttack : ScriptableObject
{

    [Header("Add area weapon here")]
    [SerializeField] GameObject areaWeapon;
    [Header("Add triple shot weapon here")]
    [SerializeField] GameObject tripleAttack;
    public void ChangeWeapon(ref GameObject weapon, PlayerSkill.SkillType e)
    {
        GameObject wep = weapon;
        switch (e)
        {
            case PlayerSkill.SkillType.TripleShot:
                weapon = tripleAttack;
                break;
            case PlayerSkill.SkillType.AreaAttack:
                weapon = areaWeapon;
                break;
            default:
                weapon = wep;
                break;
        }
    }
}
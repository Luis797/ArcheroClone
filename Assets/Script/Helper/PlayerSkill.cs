using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Helper
{
    public class PlayerSkill
    {
        public enum SkillType
        {

            ///Categories
            ///O represent healing
            ///1 represent attack
            ///2 represent physical characteristics
            Heal,
            TripleShot,
            AreaAttack,
            IncreaseSpeed,
            AttackRate,


        }

        public List<SkillType> heal = new List<SkillType>() {
            SkillType.Heal };
        public List<SkillType> attack = new List<SkillType>() {
            SkillType.AreaAttack,
            SkillType.TripleShot };
        public List<SkillType> physicalStructure = new List<SkillType>() {
            SkillType.IncreaseSpeed,
            SkillType.AttackRate };
        
        public event Action<OnSkillUnlock> OnSkillUnLocked;

        public class OnSkillUnlock
        {
            public SkillType skillType;
        }

        
        public void UnlockSkill(SkillType skillType)
        {
            OnSkillUnLocked(new OnSkillUnlock { skillType = skillType });
        }
    }
}

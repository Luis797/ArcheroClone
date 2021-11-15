using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Helper
{
    public class PlayerSkill
    {
        public enum SkillType{
            Heal,
            TripleShot,
            AreaAttack,
            IncreaseSpeed,


        }
        public  event Action<OnSkillUnlock> OnSkillUnLocked;

        public class OnSkillUnlock {
            public SkillType skillType;
        }

        public void UnlockSkill(SkillType skillType){
            OnSkillUnLocked( new OnSkillUnlock{skillType = skillType});
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Helper
{
    public class PlayerSkill
    {
        public enum SkillType{
            heal,
            headShot,
            tripleShot,

        }
        public  event EventHandler<OnSkillUnlock> OnSkillUnLocked;

        public class OnSkillUnlock : EventArgs{
            public SkillType skillType;
        }

        public void UnlockSkill(SkillType skillType){
            OnSkillUnLocked?.Invoke(this, new OnSkillUnlock{skillType = skillType});
        }
    }
}

using System;

namespace TestTask.Helper{
    public class LevelSystem {
        private int level;
         private int XPEarned;

         private int XPToNextLevel;

         public event Action OnLevelUpdate;

         public LevelSystem(){
             level = 1;
             XPEarned  =0;
             XPToNextLevel = 5;
         }

        ///<summary>
        ///Add the XP of the player and identify if the level has increased
        ///</summary>
         public void AddXp(int XP){
             XPEarned += XP;
             if(XPEarned>=XPToNextLevel){
                 level ++;
                 if(OnLevelUpdate != null ) OnLevelUpdate();
                 XPEarned -= XPToNextLevel;
             }
         }

         public float GetXPNormaized(){
            return ( float) XPEarned/XPToNextLevel;
         }

         public int Level(){
             return level;
         }
    }
}    
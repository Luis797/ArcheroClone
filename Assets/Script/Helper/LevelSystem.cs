namespace TestTask.Helper{
    public class LevelSystem {
        private int level;
         private int XPEarned;

         private int XPToNextLevel;

         public LevelSystem(){
             level = 1;
             XPEarned  =0;
             XPToNextLevel = 5;
         }

         public void AddXp(int XP){
             XPEarned += XP;
             if(XPEarned>=XPToNextLevel){
                 level ++;
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
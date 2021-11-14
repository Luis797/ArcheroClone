using UnityEngine;

namespace TestTask.Saving
{
    [System.Serializable]
    public class SaveData
    {
        public string name;

        public int coin;


        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        public void LoadFromJson(string a_Json)
        {
            JsonUtility.FromJsonOverwrite(a_Json, this);
        }
    }

    public interface ISaveable
    {

        ///<summary>
        ///Populate the json file with savedata object
        ///</summary>
        void PopulateSaveData(SaveData a_SaveData);

        ///<summary>
        ///load the json file into a savedata object
        ///</summary>
        void LoadFromSaveData(SaveData a_SaveData);
    }


}
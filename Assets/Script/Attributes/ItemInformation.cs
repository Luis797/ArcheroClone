using TestTask.Saving;
using UnityEngine;

namespace TestTask.Attribute
{

    [CreateAssetMenu(fileName = "ItemInformation", menuName = "TestTask/ItemInformation", order = 0)]
    public class ItemInformation : ScriptableObject, ISaveable
    {
        [Header("Coin required to buy the weapon")]
        [SerializeField] int coinRequired = 50;

        int currentValue;
        public void LoadFromSaveData(SaveData a_SaveData)
        {
            currentValue = a_SaveData.coin;
        }
        ///<summary>
        ///Return the current coin value which differs according to what information we are looking.
        ///If the item being checked is user info it is the total coin on hold.
        ///If the item is buyable it is the total coin required to buy the item.
        ///</summary>
        public int Coins()
        {
            LoadJsonData();
            return currentValue;
        }

        public void PopulateSaveData(SaveData a_SaveData)
        {
            a_SaveData.name = this.name;
        }
        public void LoadJsonData()
        {
            if (!FileManager.FileExits(this.name + ".dt"))
            {
                SaveData saveData = new SaveData();
                saveData.name = this.name;
                saveData.coin = coinRequired;
                FileManager.WriteToFile(this.name + ".dt", saveData.ToJson());
            }
            if (FileManager.LoadFromFile(this.name + ".dt", out var json))
            {
                SaveData saveData = new SaveData();
                saveData.LoadFromJson(json);
                LoadFromSaveData(saveData);

            }
        }
        public void SaveJsonData(int totalCoin)
        {
            SaveData saveData = new SaveData();
            saveData.coin = totalCoin;
            PopulateSaveData(saveData);
            if (FileManager.WriteToFile(this.name + ".dt", saveData.ToJson()))
            {
                Debug.Log("Success");
            }
        }

    }
}
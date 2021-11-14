using TestTask.Attribute;
using TestTask.Saving;
using UnityEngine;

namespace TestTask.Shop
{

    public abstract class IShop : MonoBehaviour
    {

        public void NextItemIndex(ref int count, int length, int i)
        {
            count += i;
            if (count >= length)
                count = 0;
            if (count < 0)
                count = length - 1;

        }

        [SerializeField] protected PlayerInformation playerInformation;

        ///Current activate Item within scene
        protected GameObject currentItem;

        ///<summary>
        ///Helps select next skin and return the amount of the next skin. Bought skin will cost 0
        ///</summary>
        public abstract int NextSkin(int i);

        ///<sumamry>
        ///Determine if the item is purchasable. (Based on the coin of the users). And if possible buys the products
        ///</summary>

        public abstract bool BuyItem(int coinRequired, out int coinLeft);

        ///<summary>
        ///Open a particular shop based.( Weapon or skin)
        ///</summary>
        public abstract void OpenShop(Transform instantiatePoint);

        ///<summary>
        ///Activities to do before switching the shop.
        ///</summary>
        public abstract void Cancel();

        ///<summary>
        ///Populate the json file with savedata object
        ///</summary>
        public abstract void PopulateSaveData(SaveData a_SaveData);

        ///<summary>
        ///load the json file into a savedata object
        ///</summary>
        public abstract void LoadFromSaveData(SaveData a_SaveData);

        ///<summary>
        ///Save data to the json file with given coin amount.
        ///</summary>
        public abstract void SaveJsonFile(int coinAmount);
    }
}
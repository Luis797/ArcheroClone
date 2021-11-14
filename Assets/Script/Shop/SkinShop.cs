using TestTask.Attribute;
using TestTask.Saving;
using UnityEngine;

namespace TestTask.Shop
{
    public class SkinShop : IShop
    {
      
        [Header("Material of the player that is used for skin")]
        [SerializeField] Material skinMaterial;

         [Header("Material of the player used in shop (Different from actual player)")]
        [SerializeField] Material ShopSkinMaterial;
        [Header("Attach Scriptable skins information")]
        [SerializeField] SkinInformation[] skins;

        int skinCount = 0;

        [SerializeField] GameObject player;

        public override bool BuyItem(int CoinCollected,out int coinleft)
        {   
            int coinRequired = skins[skinCount].Coins();
                  coinleft = CoinCollected;

             ///If the skin is bought then assign the skin to the player
            if(coinRequired == 0){
                  skinMaterial.color = skins[skinCount].color;
                return false;
            }
            if (CoinCollected <coinRequired)
                return false;
            else
            {
                CoinCollected -= coinRequired;
                coinleft = CoinCollected;
                skinMaterial.color = skins[skinCount].color;
                return true;
            }
        }
        public override int NextSkin(int i)
        {
            NextItemIndex(ref skinCount, skins.Length, i);
            ShopSkinMaterial.color = skins[skinCount].color;
            return skins[skinCount].Coins();
        }

        public override void  OpenShop(Transform instantiatePoint)
        {
           ShopSkinMaterial.color = skins[skinCount].color;
           currentItem= Instantiate(player,instantiatePoint.position,instantiatePoint.rotation);
        }

        public override void Cancel()
        {
           Destroy(currentItem);
        }

        public override void PopulateSaveData(SaveData a_SaveData)
        {
            skins[skinCount].PopulateSaveData(a_SaveData);      
        }

        public override void LoadFromSaveData(SaveData a_SaveData)
        {
               skins[skinCount].LoadFromSaveData(a_SaveData);
        }

        public override void SaveJsonFile(int coinAmount)
        {
            skins[skinCount].SaveJsonData(coinAmount);
        }
    }
}
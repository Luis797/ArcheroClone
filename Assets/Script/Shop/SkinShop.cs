using TestTask.Attribute;
using UnityEngine;

namespace TestTask.Shop
{
    public class SkinShop : IShop
    {
      
        [Header("Material of the player that is used for skin")]
        [SerializeField] Material skinMaterial;
        [Header("Attach Scriptable skin information")]
        [SerializeField] SkinInformation[] skins;

        [SerializeField] protected PlayerInformation playerInformation;

        int skinCount = 0;

        [SerializeField] GameObject player;

        public override void BuyItem()
        {
            if (playerInformation.CoinCollected < skins[skinCount].coinRequired)
                Debug.Log("Cannot buy the item");
            else
            {

            }
        }
        public override int NextSkin(int i)
        {
            NextItemIndex(ref skinCount, skins.Length, i);
            skinMaterial.color = skins[skinCount].color;
            return skins[skinCount].coinRequired;
        }

        public override GameObject OpenShop()
        {
            return player;
        }


    }
}
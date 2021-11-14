using UnityEngine;
using TestTask.Attribute;
using UnityEngine.UI;
using TestTask.Saving;

namespace TestTask.Shop
{
    public class ShopManager : MonoBehaviour
    {

        [Header("Position where the item is instantiate")]
        [SerializeField] Transform instantiatePoint;
        [Header("Add the text of the button that shows the price of the iten")]
        [SerializeField] Text priceText;

        [Header("Add adstarct class of the initial shop to open")]
        [SerializeField] IShop skin;

        [Header("Add coin available")]
        [SerializeField] Text coinAvailable;

        IShop shop = null;

        int totalCoinAvailable;
        int coinsRequired = 0;

        [SerializeField] protected PlayerInformation playerInformation;

        private void Start()
        {
            OpenShop(skin);
            totalCoinAvailable = playerInformation.Coins();
            CoinAvailable();
        }

        //Add this to buttons to switch between shops
        //For each shop there must be seperate scipts that extends IShop abstraction class
        //Accordingly the shops are swipe
        public void OpenShop(IShop shop)
        {
            if (this.shop == shop)
                return;
            if (this.shop != null)
                this.shop.Cancel();
            this.shop = shop;
            shop.OpenShop(instantiatePoint);
        }
        //Assign this to the next and previous button. For next the value is 1 and for previous -1
        public void NextSkin(int i)
        {
            //if 
            coinsRequired = shop.NextSkin(i);

            if (coinsRequired == 0)
                priceText.text = "Attach";
            else
                priceText.text = coinsRequired.ToString();
        }

        private void CoinAvailable()
        {
            coinAvailable.text = "Coin Available " + totalCoinAvailable;
        }

        ///Buy the particular selected item
        public void BuyItem()
        {
            totalCoinAvailable = playerInformation.Coins();
            int coinLeft;
            if (shop.BuyItem(totalCoinAvailable, out coinLeft))
            {
                shop.SaveJsonFile(0);
                playerInformation.SaveJsonData(coinLeft);
                totalCoinAvailable = coinLeft;
                priceText.text = "Attach";
                CoinAvailable();

            }
        }
    }
}


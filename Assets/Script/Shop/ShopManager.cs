using UnityEngine;
using TestTask.Attribute;
using UnityEngine.UI;
using System;

namespace TestTask.Shop
{
    public class ShopManager : MonoBehaviour
    {
      

       

        [Header("Position where the item is instantiate")]
        [SerializeField] Transform instantiatePoint;

        [SerializeField] Text priceText;

        int skinCount = 0;

        GameObject currentItem;

        IShop shop = null;
        [SerializeField] IShop skin,weapon;
        private void Start() {
          OpenShop(skin);
        }

        public void OpenShop(IShop shop)
        {
           if (this.shop == shop)
           return; 
           Destroy(currentItem);
           this.shop = shop;
           currentItem = Instantiate(skin.OpenShop(),instantiatePoint.position,instantiatePoint.rotation);
        }

        public void NextSkin(int i)
        {
          int coinsRequired = skin.NextSkin(i);
          priceText.text = coinsRequired.ToString();
        }

       

       

       
    }
}


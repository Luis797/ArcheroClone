using UnityEngine;
using TestTask.Attribute;
using UnityEngine.UI;

namespace TestTask.Shop
{
    public class ShopManager : MonoBehaviour
    {
        [System.Serializable]
        public class Weapon
        {
            [Header("Attach Scriptable weapon information")]
            [SerializeField] WeponInfromation weponInfromations;
            [Header("Attach corresponding weapon information")]
            [SerializeField] GameObject weapon;

        }
        [Header("Attach Scriptable player information")]
        [SerializeField] PlayerInformation playerInformation;
        ///This is the change in the skin of the player
        [Header("Define the colors which can be bought through coin")]
        [SerializeField] Color[] colors;

        [Header("Material of the player that is used for skin")]
        [SerializeField] Material skinMaterial;

        [Header("Position where the item is instantiate")]
        [SerializeField] Transform instantiatePoint;
        [SerializeField] Weapon[] Weapons;

        [SerializeField] GameObject player;

        [SerializeField] Text priceText;

        int skinCount = 0;
        int weaponCount = 0;

        GameObject currentItem;

        bool skin = false, weapon = false;
        private void Start() {
            ShopPlayerSkin();
        }

        ///Switch to skin shop
        public void ShopPlayerSkin()
        {
            if (skin) return;
            weapon = false;
            skin = true;
            priceText.text = (50).ToString();
            InstantiateNextItem(player);
        }

        private void InstantiateNextItem(GameObject item)
        {
            Destroy(currentItem);
            currentItem = Instantiate(item, instantiatePoint.position, instantiatePoint.rotation);
        }

        public void NextSkin(int i)
        {
            int itemNumebr = NextItemIndex(ref skinCount,colors.Length,i);
            skinMaterial.color = colors[skinCount];
        }

        ///<summary>
        ///Next item index of he given shop item. Returns zero after final item
        ///</summary>
        private int NextItemIndex(ref int count,int length,int i)
        {
            count += i;
            if (count >= length)
                count = 0;
            if (count < 0)
                count = length - 1;
            return count;
        }

        private void purchaseSkin(){
            if(playerInformation.CoinCollected<50)
                Debug.Log("Cannot buy the item");
            else{
                
            }
        }
    }
}


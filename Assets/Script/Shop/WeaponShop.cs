using TestTask.Attribute;
using TestTask.Saving;
using UnityEngine;

namespace TestTask.Shop
{

    public class WeaponShop : IShop,ISaveable
    {
        [System.Serializable]
        public class Weapon
        {
            [Header("Attach Scriptable weapon information")]
            [SerializeField] public WeponInfromation weponInfromations;
           
            [Header("Attach corresponding Show Case weapon")]
            [SerializeField] public GameObject showCaseWeapon;
              [Header("Attach corresponding Show Case weapon")]
            [SerializeField] public GameObject weapon;

        }

        [SerializeField] Weapon[] Weapons;

        int weaponCount = 0;
        public override bool BuyItem(int CoinCollected,out int coinLeft)
        {

            WeponInfromation weponInformation = Weapons[weaponCount].weponInfromations;
            int coinRequired = weponInformation.Coins();
            coinLeft = CoinCollected;
            ///If the item is already bought then assign the weapon to the player
            if (coinRequired == 0)
            {
                playerInformation.weapon = Weapons[weaponCount].weapon;
                return false;
            }
            //Check if there is available amout of coins
            if (CoinCollected < coinRequired)
                return false;
            else
            {
                CoinCollected -= coinRequired;
                coinLeft = CoinCollected;
                playerInformation.weapon = Weapons[weaponCount].weapon;
                return true;
            }

        }

        public override int NextSkin(int i)
        {
            NextItemIndex(ref weaponCount, Weapons.Length, i);
            Destroy(currentItem);
            Weapon weapon = Weapons[weaponCount];
            currentItem = Instantiate(weapon.showCaseWeapon, transform.position, transform.rotation);
            return weapon.weponInfromations.Coins();
        }

        public override void OpenShop(Transform instantiatePoint)
        {
            currentItem = Instantiate(Weapons[weaponCount].showCaseWeapon, instantiatePoint.position, instantiatePoint.rotation);
        }

        public override void Cancel()
        {
            Destroy(currentItem);
        }

         public override void PopulateSaveData(SaveData a_SaveData)
        {
                 Weapons[weaponCount].weponInfromations.PopulateSaveData(a_SaveData);
        }

        public override void LoadFromSaveData(SaveData a_SaveData)
        {
                Weapons[weaponCount].weponInfromations.LoadFromSaveData(a_SaveData);
        }

        public override void SaveJsonFile(int coinAmount)
        {
           Weapons[weaponCount].weponInfromations.SaveJsonData(coinAmount);
        }
    }
}
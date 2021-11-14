using TestTask.Attribute;
using UnityEngine;

namespace TestTask.Shop
{

    public class WeaponShop : IShop
    {
        [System.Serializable]
        public class Weapon
        {
            [Header("Attach Scriptable weapon information")]
            [SerializeField]public WeponInfromation weponInfromations;
            [Header("Attach corresponding weapon information")]
            [SerializeField]public GameObject weapon;

        }

        [Header("Attach Scriptable player information")]
        [SerializeField] PlayerInformation playerInformation;
        [SerializeField] Weapon[] Weapons;
        int weaponCount = 0;

        GameObject currentItem;

        public override void BuyItem()
        {
            throw new System.NotImplementedException();
        }

        public override int NextSkin(int i)
        {
             NextItemIndex(ref weaponCount,Weapons.Length,i);
            Destroy(currentItem);
            Weapon weapon = Weapons[weaponCount];
            currentItem = Instantiate(weapon.weapon,transform.position,transform.rotation);
            return weapon.weponInfromations.coinRequired;
        }

        public override GameObject OpenShop()
        {
            return Weapons[weaponCount].weapon;
        }

    }
}
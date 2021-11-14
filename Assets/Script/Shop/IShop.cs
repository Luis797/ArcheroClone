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
        public abstract int NextSkin(int i);
        public abstract void BuyItem();
        public abstract GameObject OpenShop();

    }
}
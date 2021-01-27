using System;
using System.Collections.Generic;
using System.Text;
using ES.BusinessLayer.Interfaces;
using ES.BusinessLayer.Levels;

namespace ES.BusinessLayer
{
    public class BusinessManager
    {
        public IUser GetUserBL()
        {
            return new UserLevel();
        }

        public IShop GetShopBL()
        {
            return new ShopLevel();
        }

    }
}

using ES.BusinessLayer.Implementation;
using ES.BusinessLayer.Interfaces;
using ES.Domain.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ES.BusinessLayer.Levels
{
    public class ShopLevel : ShopImplementation, IShop
    {
        public async Task<ResponseModel> AddProducts(ProductsModel model)
        {
            return await AddProductAction(model);
        }
    }
}

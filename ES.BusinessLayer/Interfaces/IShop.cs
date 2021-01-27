using ES.Domain.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ES.BusinessLayer.Interfaces
{
    public interface IShop
    {
        Task<ResponseModel> AddProducts(ProductsModel model);
    }
}

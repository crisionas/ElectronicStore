using ES.BusinessLayer.DBModels;
using ES.Domain.Entities;
using ES.Domain.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.BusinessLayer.Implementation
{
    public class ShopImplementation
    {
        internal async Task<ResponseModel> AddProductAction(ProductsModel model)
        {
            if(model.Type=="appliance")
            {
                using(var db=new ShopContext())
                {
                    var data = new ApplianceProducts
                    {
                        Brand = db.ApplianceBrands.FirstOrDefault(m=>m.BrandId==Int32.Parse(model.Brand)),
                        Category = db.ApplianceCategories.FirstOrDefault(d=>d.CategoryId==Int32.Parse(model.Category)),
                        Description = model.Description,
                        Details = model.Details,
                        Mark = model.Mark,
                        Price = model.Price,
                        ProductImage1 = model.Images[0],
                        ProductImage2 = model.Images[1],
                        ProductImage3 = model.Images[2]
                    };
                    await db.ApplianceProducts.AddAsync(data);
                    db.SaveChanges();
                }
            }
            return null;
        }

    }
}

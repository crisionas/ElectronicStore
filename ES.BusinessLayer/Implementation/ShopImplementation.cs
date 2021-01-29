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
            if (model.Type == "appliance")
            {
                try
                {
                    using (var db = new ShopContext())
                    {
                        var data = new ApplianceProducts
                        {
                            Brand = db.ApplianceBrands.FirstOrDefault(m => m.BrandId == Int32.Parse(model.Brand)),
                            Category = db.ApplianceCategories.FirstOrDefault(d => d.CategoryId == Int32.Parse(model.Category)),
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
                    return new ResponseModel
                    {
                        Status = true,
                        Message = "Your appliance product was added successfully."
                    };
                }
                catch (Exception e)
                {
                    return new ResponseModel
                    {
                        Status = false,
                        Message = e.Message
                    };
                }

            }
            else if (model.Type == "electronics")
            {
                try
                {
                    using (var db = new ShopContext())
                    {
                        var data = new ElectroProducts();
                        data.Brand = db.ElectroBrands.FirstOrDefault(m => m.BrandId == Int32.Parse(model.Brand));
                            data.Category = db.ElectroCategories.FirstOrDefault(d => d.CategoryId == Int32.Parse(model.Category));
                            data.Description = model.Description;
                            data.Details = model.Details;
                            data.Mark = model.Mark;
                            data.Price = model.Price;
                            data.ProductImage1 = model.Images[0];
                            data.ProductImage2 = model.Images[1];
                            data.ProductImage3 = model.Images[2];
                        await db.ElectroProducts.AddAsync(data);
                        db.SaveChanges();
                    }
                    return new ResponseModel
                    {
                        Status = true,
                        Message = "Your electronic product was added successfully."
                    };
                }

                catch (Exception e)
                {
                    return new ResponseModel
                    {
                        Status = false,
                        Message = e.Message
                    };
                }
            }
            return new ResponseModel
            {
                Status = false,
                Message = "????"
            };
        }
    }

}


using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsStore.Models;
using ES.BusinessLayer.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.WebEncoders.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using ES.BusinessLayer.Interfaces;
using ES.Domain.Models.Shop;
using ES.BusinessLayer;
using ES.Domain.Entities;

namespace ElectronicsStore.Controllers
{
    public class ShopController : Controller
    {
        private IShop shop;

        public ShopController()
        {
            var bl = new BusinessManager();
            shop = bl.GetShopBL();
        }

        
        [AllowAnonymous]
        public ActionResult Electronics()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult Appliances()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> AddProduct()
        {

            try
            {
                using (var db = new ShopContext())
                {
                    ViewBag.ApplianceCategories = await db.ApplianceCategories.ToListAsync();
                    ViewBag.ElectroCategories= await db.ElectroCategories.ToListAsync();
                    ViewBag.ElectroBrand = await db.ElectroBrands.ToListAsync();
                    ViewBag.ApplianceBrand = await db.ApplianceBrands.ToListAsync();

                }
                
            }
            catch
            { }
            
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddProduct(AddProdViewModel model, List<IFormFile> Images)
        {
            var list =new List<byte[]>();
            foreach (var item in Images)
            {
                using (var stream = new MemoryStream())
                {
                    await item.CopyToAsync(stream);
                    list.Add(stream.ToArray());
                }
            }
            var data = new ProductsModel
            {
                Brand = model.Brand,
                Description = model.Description,
                Details = model.Details,
                Category=model.Category,
                Mark=model.Mark,
                Images=list,
                Price=model.Price,
                Type=model.Type
            };

            var response = shop.AddProducts(data);


            return RedirectToAction("Index","Home");
        }
        
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetElectronicCategories()
        {
            try
            {
                using (var db = new ShopContext())
                {
                    List<CategoryModel> modelCategory = new List<CategoryModel>();
                    var categories = db.ElectroCategories.ToList();
                    foreach (var item in categories)
                    {
                        modelCategory.Add(new CategoryModel
                        {
                            id = item.CategoryId,
                            Name = item.Name
                        });
                    }

                    return Json(modelCategory);
                }
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetElectronicProducts()
        {
            try
            {
                List<ProductsViewModel> model = new List<ProductsViewModel>();
                using (var db = new ShopContext())
                {
                    var productsList = db.ElectroProducts
                        .Join(db.ElectroCategories, ep => ep.CategoryId, ec => ec.CategoryId, (ep, ec) => new { ep, ec })
                        .Join(db.ElectroBrands, ep => ep.ep.BrandId, eb => eb.BrandId, (ep, eb) => new { ep, eb }).ToList();
                    foreach (var item in productsList)
                    {
                        var viewModel = new ProductsViewModel();
                        viewModel.id = item.ep.ep.ID;
                        viewModel.Category = item.ep.ec.Name;
                        viewModel.Brand = item.eb.Name;
                        viewModel.Mark = item.ep.ep.Mark;
                        viewModel.Details = item.ep.ep.Details;
                        viewModel.Price = item.ep.ep.Price;
                        viewModel.Description = item.ep.ep.Description;
                        viewModel.Image1 = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(item.ep.ep.ProductImage1));

                        model.Add(viewModel);
                    }
                }
                return Json(model);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        [HttpGet]
        public JsonResult GetApplianceProducts()
        {
            List<ProductsViewModel> list = new List<ProductsViewModel>();

            try
            {
                using (var db = new ShopContext())
                {
                    var applianceproducts = db.ApplianceProducts.Join(db.ApplianceCategories, d => d.CategoryId, m => m.CategoryId, (d, m) => new { d, m })
                        .Join(db.ApplianceBrands, e => e.d.BrandId, b => b.BrandId, (e, b) => new { e, b }).ToList();
                    foreach(var item in applianceproducts)
                    {
                        var model = new ProductsViewModel
                        {
                            id = item.e.d.BrandId,
                            Category = item.e.m.Name,
                            Brand=item.b.Name,
                            Details=item.e.d.Details,
                            Description=item.e.d.Description,
                            Price=item.e.d.Price,
                            Mark=item.e.d.Mark,
                            Image1=String.Format("data:image/png;base64,{0}", Convert.ToBase64String(item.e.d.ProductImage1))
                        };
                        list.Add(model);
                    }
                }
                return Json(list);
            }
            catch(Exception e)
            {
                return Json(e);
            }
        }
        

    }
}

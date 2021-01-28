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
        public ActionResult Electronic()
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
        public async Task<JsonResult> GetElectronicCategories()
        {
            try
            {
                using (var db = new ShopContext())
                {
                    List<CategoryModel> modelCategory = new List<CategoryModel>();
                    var categories = await db.ElectroCategories.ToListAsync();
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
        public async Task<JsonResult> GetElectronicProducts()
        {
            try
            {
                List<ElectroProductsViewModel> model = new List<ElectroProductsViewModel>();
                using (var db = new ShopContext())
                {
                    var productsList = await db.ElectroProducts
                        .Join(db.ElectroCategories, ep => ep.Category.CategoryId, ec => ec.CategoryId, (ep, ec) => new { ep, ec })
                        .Join(db.ElectroBrands, ep => ep.ep.Brand.BrandId, eb => eb.BrandId, (ep, eb) => new { ep, eb }).ToListAsync();
                    foreach (var item in productsList)
                    {
                        var viewModel = new ElectroProductsViewModel();
                        viewModel.id = item.ep.ep.ID;
                        viewModel.Category = item.ep.ec.Name;
                        viewModel.Brand = item.eb.Name;
                        viewModel.Mark = item.ep.ep.Mark;
                        viewModel.Details = item.ep.ep.Details;
                        viewModel.Price = item.ep.ep.Price;
                        viewModel.Description = item.ep.ep.Description;
                        if(item.ep.ep.ProductImage1 != null)
                        //viewModel.Image1 = string.Format("data:image/png;base64,{0}",
                        //    Convert.ToBase64String(item.ep.ep.ProductImage1));
                        
                        //if (item.ep.ep.ProductImage2!=null && item.ep.ep.ProductImage3 != null)
                        //{
                        //    viewModel.Image2 = string.Format("data:image/png;base64,{0}",
                        //        Convert.ToBase64String(item.ep.ep.ProductImage2));
                        //    viewModel.Image3 = string.Format("data:image/png;base64,{0}",
                        //        Convert.ToBase64String(item.ep.ep.ProductImage3));
                        //}



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


    }
}

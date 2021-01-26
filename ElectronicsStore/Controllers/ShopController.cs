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

namespace ElectronicsStore.Controllers
{
    public class ShopController : Controller
    {
        [AllowAnonymous]
        public ActionResult Electronic()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddProduct()
        {

            try
            {
                using (var db = new ShopContext())
                {
                    ViewBag.ApplianceCategories = db.ApplianceCategories.ToList();
                    ViewBag.ElectroCategories= db.ElectroCategories.ToList();
                    ViewBag.ElectroBrand = db.ElectroBrands.ToList();
                    ViewBag.ApplianceBrand = db.ApplianceBrands.ToList();

                }
                
            }
            catch(Exception e)
            { }
            
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddProduct(AddProdViewModel model)
        {
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
                List<ElectroProductsViewModel> model = new List<ElectroProductsViewModel>();
                using (var db = new ShopContext())
                {
                    var productsList = db.ElectroProducts
                        .Join(db.ElectroCategories, ep => ep.Category.CategoryId, ec => ec.CategoryId, (ep, ec) => new { ep, ec })
                        .Join(db.ElectroBrands, ep => ep.ep.Brand.BrandID, eb => eb.BrandID, (ep, eb) => new { ep, eb }).ToList();
                    foreach (var item in productsList)
                    {
                        var viewModel = new ElectroProductsViewModel();
                        viewModel.id = item.ep.ep.ID;
                        viewModel.Name = item.ep.ep.Name;
                        viewModel.Category = item.ep.ec.Name;
                        viewModel.Brand = item.eb.Name;
                        viewModel.Mark = item.ep.ep.Mark;
                        viewModel.Details = item.ep.ep.Details;
                        viewModel.Price = item.ep.ep.Price;
                        viewModel.Description = item.ep.ep.Description;
                        if(item.ep.ep.ProductImage1 != null)
                        viewModel.Image1 = string.Format("data:image/png;base64,{0}",
                            Convert.ToBase64String(item.ep.ep.ProductImage1));
                        
                        if (item.ep.ep.ProductImage2!=null && item.ep.ep.ProductImage3 != null)
                        {
                            viewModel.Image2 = string.Format("data:image/png;base64,{0}",
                                Convert.ToBase64String(item.ep.ep.ProductImage2));
                            viewModel.Image3 = string.Format("data:image/png;base64,{0}",
                                Convert.ToBase64String(item.ep.ep.ProductImage3));
                        }



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

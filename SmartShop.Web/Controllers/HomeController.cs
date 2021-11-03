using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShop.DataLib.Models.Data;
using SmartShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.IO;

namespace SmartShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SmartShopDbContext _db;

        public HomeController(SmartShopDbContext db)
        {
            _db = db;
        }

        //for home page
        public IActionResult Index()
        {
            var Products = _db.Products
             .Include(x => x.Subcategory.Category)
             .Include(x => x.Brand)
             .Include(x => x.ProductPrices)
          
             .Include(x => x.Subcategory)
             .Include(x => x.ProductImages)
             .ToList();
            return View(Products);
        }

       


    }
}

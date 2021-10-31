using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShop.DataLib.Models.Data;
using SmartShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
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

        public IActionResult Index()
        {
            IndexVM indexVM = new IndexVM()
            {
                Products = _db.Products
               
                .Include(x => x.Brand)
                .Include(x=>x.ProductPrices)
               
                .Include(x=>x.ProductImages)
                .Include(x => x.Reviews)
                .ThenInclude(x=>x.Customer)
                 .Include(x => x.Subcategory)
             
                .ToList(),
                Categories = _db.Categories.ToList(),
                Subcategories = _db.Subcategories.ToList(),
                Brands = _db.Brands.ToList(),
               
          
            };

            return View(indexVM);
        }

       


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShop.DataLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly SmartShopDbContext _db;
        public ProductController(SmartShopDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            var Products = _db.Products
                .Include(x=>x.Subcategory.Category)
                .Include(x=>x.Brand)
       
                .Include(x => x.ProductPrices)
                .Include(x => x.ProductSpecs)
                .Include(x=>x.Subcategory)
                 .Include(x => x.ProductImages)
                .ToList();
            return View(Products);
        }
        public IActionResult ProductDetails(int id)
        {
            var Product = _db.Products.Where(x => x.ProductId.Equals(id))
             
                .Include(x=>x.Brand)
                .Include(x=>x.ProductImages)
                .Include(x=>x.Subcategory)
                 .Include(x => x.ProductPrices)
                 .Include(x => x.ProductSpecs)
                .Include(x=>x.Reviews)
              
                .ThenInclude(x=>x.Customer)
                .FirstOrDefault();
            return View(Product);
        }
    }
}

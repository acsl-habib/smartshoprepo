using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShop.DataLib.Models.Data;
using SmartShop.Web.ViewModels;
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

        //product page controller
        public IActionResult Index()
        {
            var Products = _db.Products
                .Include(x=>x.Subcategory.Category)
                .Include(x=>x.Brand)
                .Include(x => x.ProductPrices)
                //.Include(x => x.ProductSpecs)
                .Include(x=>x.Subcategory)
                .Include(x => x.ProductImages)
            

                .ToList();
            return View(Products);
        }
        //product details page
        public IActionResult ProductDetails(int id)
        {
            ProductViewVM productViewVM = new ProductViewVM()
            {
                Product = _db.Products.Where(x => x.ProductId.Equals(id))

                .Include(x => x.Brand)
                .Include(x => x.ProductImages)
                .Include(x => x.Subcategory)
                 .Include(x => x.ProductPrices)
                   .Include(x => x.ProductSpecs)

                .Include(x => x.Reviews)

                .ThenInclude(x => x.Customer)
                .FirstOrDefault(),
                

        };

            return View(productViewVM);
        }
    }
}

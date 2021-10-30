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
    public class SearchController : Controller
    {
        private readonly SmartShopDbContext _db;
        public SearchController(SmartShopDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchProduct(string search)
        {
            if (search!=null)
            {
              var   SearchProduct = _db.Products
                    .Where(x => x.ProductName.Contains(search))
               
                    .Include(x=>x.Brand)
                       .Include(x => x.ProductImages)
                .Include(x => x.Reviews)
                    .Include(x=>x.Subcategory)
                    .ToList();
       
                IndexVM SearchVM = new IndexVM()
                {
                    Products=SearchProduct
                };
                return View(SearchVM);
            }
    
            
            return View();
        }

        public IActionResult CategoryProduct(int id)
        { 
            var Products = _db.Products.Where(x=>x.SubcategoryId.Equals(id))
                  
                    .Include(x => x.Brand)
                    .Include(x => x.Subcategory)
                    .Include(x => x.ProductImages)
                    .Include(x => x.Reviews)
                    .ToList();
            IndexVM ProductVM = new IndexVM()
            {
                Products = Products
            };
            return View(ProductVM);
       
        }
    }
}

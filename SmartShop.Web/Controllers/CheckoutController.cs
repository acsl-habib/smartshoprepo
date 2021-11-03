using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShop.DataLib.Models.Data;
using SmartShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartShop.Web.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly SmartShopDbContext _db;

        public CheckoutController(SmartShopDbContext db)
        {
            _db = db;
        }

        //checkout page
         public IActionResult Index()
         {
             var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
             var Customer = _db.Customers.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
             var CustomerId = Customer.CustomerId;
             CheckoutVM checkoutVM = new CheckoutVM()
             {
                 Payments = _db.Payments.ToList(),
                 Shipping = _db.Shippings.ToList(),
                 Total = _db.Carts
                 
                 .Where(x => x.CustomerId.Equals(CustomerId)).Sum(x => x.ProductPrice * x.Quantity),

                 Carts = _db.Carts
            
                 .Where(x => x.CustomerId.Equals(CustomerId))
                 .Include(x => x.Product.ProductImages)
                .Include(x => x.Product.ProductPrices)
                  .Include(x => x.Product)
                  .ThenInclude(x=>x.Brand)
                 .ToList(),
                 Customer = _db.Customers.Where(x => x.CustomerId.Equals(CustomerId)).FirstOrDefault(),


             };
             return View(checkoutVM);
         }
    }
}

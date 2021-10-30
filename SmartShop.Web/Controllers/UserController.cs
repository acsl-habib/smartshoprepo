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
    public class UserController : Controller
    {
        private readonly SmartShopDbContext _db;

        public UserController(SmartShopDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Customer = _db.Customers.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
            var CustomerId = Customer.CustomerId;
            OrderVM orderVM = new OrderVM()
            {

                Orders = _db.Orders
                .Where(x => x.CustomerId.Equals(CustomerId))
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .ToList(),
                Total = _db.OrderDetails
                 .Where(x => x.OrderId.Equals(x.OrderId))
                 .Sum(x => x.ProductPrice * x.Quantity),


            };
            return View(orderVM);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShop.DataLib.Models.Data;
using SmartShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SmartShop.Web.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        readonly SmartShopDbContext _db = null;
        private readonly UserManager<IdentityUser> _userManager;

        public CartSummaryViewComponent(SmartShopDbContext db, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            this._db = db;
        }
         public async Task<IViewComponentResult> InvokeAsync()
         {

              var Id=  HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
           
            if (Id != null)
            {
                var Customer = _db.Customers.Where(x => x.UserId.Equals(Id)).FirstOrDefault();
                var CusId = Customer.CustomerId;
                var count = _db.Carts
              .Where(x => x.CustomerId.Equals(CusId))
              .Count();
                var item = await Task.FromResult<CartSummaryVM>(new CartSummaryVM { CartCount = count });
                return View(item);

            }
            else
            {
                var count = 0;
                var item = await Task.FromResult<CartSummaryVM>(new CartSummaryVM { CartCount = count });
                return View(item);
            }


       
         }
    }
}

using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class CartController : Controller
    {
   
        readonly SmartShopDbContext _db = null;

        private readonly INotyfService _notyf;


        public CartController(SmartShopDbContext db, INotyfService notyf)
        {
            this._db = db;
            _notyf = notyf;

        }

         //public IActionResult Index()
         //{
      
         //    var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
         //    var Customer = _db.Customers.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
         //    var CustomerId = Customer.CustomerId;
         //    var Carts = _db.Carts
         //       .Where(x => x.CustomerId.Equals(CustomerId))
         //       .Include(x => x.Product)
         //       .Include(x => x.Product.ProductImages)
         //       .Include(x => x.Product.ProductPrices)
         //       .Include(x => x.Product.Brand)
         //       .ToList();
         //    var cartVM = new CartVM()
         //    {         
         //          Carts = Carts,
         //           Total = _db.Carts
         //           .Where(x => x.CustomerId.Equals(CustomerId)).Sum(x=>x.ProductPrice* x.Quantity),
         //    };
         //    return View(cartVM);
         //}

         //[HttpGet]
         //public IActionResult AddToCart(int id)
         //{
   
         //   //user id
         //    var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
         //   //customer
         //    var Customer = _db.Customers.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
         //   //customer id
         //    var CustomerId = Customer.CustomerId;
         //   //product price
         //    var ProductPrice = _db.ProductPrices.Where(x => x.ProductId.Equals(id)).First();

         //   //product 
         //    var product = _db.Products.Where(x => x.ProductId.Equals(id)).FirstOrDefault();
         //   //check product
         //    var checkProduct = _db.Carts.Where(x => x.CustomerId.Equals(CustomerId)).Where(x => x.ProductId.Equals(id)).FirstOrDefault();
         //    if (checkProduct != null)
         //    {

         //        checkProduct.Quantity = checkProduct.Quantity + 1;

         //        _db.SaveChanges();
         //        _notyf.Success("Product added to your card", 2);
         //        var total_cart = _db.Carts.Where(x => x.CustomerId.Equals(CustomerId)).Count();
         //       Json(total_cart);
         //       return Json(total_cart);
         //   }
         //    else
         //    {
         //        var cart = new Cart()
         //        {
         //            CustomerId = CustomerId,
         //            ProductId = id,
         //            Quantity = 1,
         //            ProductPrice= ProductPrice.Price,
         //        };
         //        _db.Carts.Add(cart);
             
         //        _db.SaveChanges();
         //        _notyf.Success("Product added to your card", 2);
         //        var total_cart = _db.Carts.Where(x => x.CustomerId.Equals(CustomerId)).Count();
         //      return Json(total_cart);
            
         //    }

         //}


          //public IActionResult RemoveCart(int id)
          //{
          //    var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
          //    var Customer = _db.Customers.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
          //    var CustomerId = Customer.CustomerId;

          //    var carts = _db.Carts.Where(x => x.CustomerId.Equals(CustomerId))
          //        .Where(x => x.ProductId.Equals(id)).FirstOrDefault();


          //    _db.Entry(carts).State = EntityState.Deleted;

          //    _db.SaveChanges();
          //    _notyf.Success("Cart remove from your cart", 3);
          //    return RedirectToAction("Index");
          //}


         //public IActionResult AddQuantity(CartVM model, int id)
         //{
         //    var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
         //    var Customer = _db.Customers.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
         //    var CustomerId = Customer.CustomerId;

         //    //var checkProduct = _db.Carts.Where(x => x.CustomerId.Equals(CustomerId)).Where(x => x.ProductId.Equals(id)).FirstOrDefault();
         //    if (checkProduct != null)
         //    {

         //        checkProduct.Quantity = model.Quantity;

         //        _db.SaveChanges();
         //        return RedirectToAction("Index");
         //    }
         //    return RedirectToAction();
         //}
    }
}

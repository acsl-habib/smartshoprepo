﻿using Microsoft.AspNetCore.Authorization;
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
    public class OrderController : Controller
    {
        private readonly SmartShopDbContext _db;

        public OrderController(SmartShopDbContext db)
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
                 .Where(x =>x.OrderId.Equals(x.OrderId))
                 .Sum(x => x.ProductPrice * x.Quantity),
             };
             return View(orderVM);
         }

         public IActionResult OrderDetails()
         {
             return View();
         }


         [HttpPost]
         public IActionResult OrderStore(CheckoutVM model)
         {
             if (ModelState.IsValid)
             {
                //user id
                 var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                //customer
                 var Customer = _db.Customers.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
                //customer id
                 var CustomerId = Customer.CustomerId;

                //order
                 var NewOrder = new Order()
                 {
          
                     PaymentName = model.PaymentName,
                     Comment = model.Message,
                     CustomerId = CustomerId,
                     OrderDate = DateTime.Now,
                     ShippingId = model.ShippingId,
                     IsConfirmed=false,
                     TrxId= "12334",
                   


                 };
       
                 _db.Orders.Add(NewOrder);
                 _db.SaveChanges();
              
                //check customer details
                 var CheckCustomer = _db.Customers
                     .Where(x => x.CustomerId == CustomerId)
                      .Where(x => x.CustomerName == null)
                       .Where(x => x.Address == null)
                        .Where(x => x.Phone == null)
                     .FirstOrDefault();
                 if (CheckCustomer != null)
                 {
                     CheckCustomer.Address = model.Address;
                     CheckCustomer.CustomerName = model.CustomerName;
                     CheckCustomer.Phone = model.Phone;
                     _db.SaveChanges();
                 }

                 //all carts
                 var Carts = _db.Carts.Where(x => x.CustomerId.Equals(CustomerId)).ToList();
                 if (Carts != null)
                 {
                     foreach (var c in Carts)
                     {
                        //create order details
                        var orderDetails = new OrderDetail()
                        {
                            OrderId = NewOrder.OrderId,
                            ProductId = c.ProductId,
                            Quantity = c.Quantity,
                            ProductPrice = c.ProductPrice,
                        };
                        _db.OrderDetails.Add(orderDetails);
                        _db.SaveChanges();

                        //delete cart
                        _db.Entry(c).State = EntityState.Deleted;

                        _db.SaveChanges();
                     }
                 }



                 return RedirectToAction("Index");

             }

             return View(model);


         }
    }
}

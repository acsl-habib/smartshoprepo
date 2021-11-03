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
    public class ReviewController : Controller
    {
        private readonly SmartShopDbContext _db;
        public ReviewController(SmartShopDbContext db)
        {
            this._db = db;
        }

        //review index
        public IActionResult Index(int id)
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Customer = _db.Customers.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
            var CustomerId = Customer.CustomerId;
            var Review = _db.Reviews.Where(x => x.CustomerId.Equals(CustomerId)).FirstOrDefault();
            var Product = _db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            var reviewVM = new ReviewVM()
            {
                Product =Product,
                Review = Review,
        };



            return View(reviewVM);
        }
        //add review
        public IActionResult ReviewStore(ReviewVM model)
        {
            if (ModelState.IsValid)
            {
                var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var Customer = _db.Customers.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
                var CustomerId = Customer.CustomerId;
                var checkReview = _db.Reviews
                    .Where(x => x.ProductId.Equals(model.ProductId))
                    .Where(x => x.CustomerId.Equals(CustomerId)).FirstOrDefault();
                if (checkReview != null)
                {
                    var Review = _db.Reviews.Where(x => x.ProductId.Equals(model.ProductId)).Where(x => x.CustomerId.Equals(CustomerId)).FirstOrDefault();

                    if (Review != null)
                    {
                        Review.Comment = model.Comment;
                        Review.Rating = model.Rating;
                        _db.SaveChanges();
                        return RedirectToAction("Index", "Order");
                    }
                }
                else
                {
                    var Review = new Review()
                    {
                        Rating = model.Rating,
                        Comment = model.Comment,
                        ProductId = model.ProductId,
                        CustomerId = CustomerId
                    };
                    _db.Reviews.Add(Review);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Order");

                }

        
     
                return RedirectToAction("Index", "Order");
            }
            return RedirectToAction("Index", "Order");
        }


     
    }
}

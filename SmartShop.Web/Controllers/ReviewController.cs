using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }
        //public IActionResult ReviewStore(ProductReviewVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
                
        //        var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        var Customer = _db.Customers.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
        //        var CustomerId = Customer.CustomerId;
        //        var  Review = new Review()
        //        {
        //            Rating = model.Rating,
        //            Comment = model.Comment,
        //            ProductId= model.ProductId,
        //            CustomerId = CustomerId
        //        };
        //        _db.Reviews.Add(Review);
        //        _db.SaveChanges();
        //        var OrderDetail = _db.OrderDetails.Where(x=>x.ProductId.Equals(model.ProductId)).FirstOrDefault();
        //        if (OrderDetail != null)
        //        {
        //            OrderDetail.ReviewStatus = true;
        //            _db.SaveChanges();
        //        }
            
               
        //        return RedirectToAction("Index", "Order");
        //    }
        //    return View(model);
        //}


        //public IActionResult Edit(int id)
        //{

        //    var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var Customer = _db.Customers.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
        //    var CustomerId = Customer.CustomerId;
        //    var review = _db.Reviews.Where(x => x.ProductId.Equals(id)).Where(x => x.CustomerId.Equals(CustomerId)).FirstOrDefault();
        //    var reviewVM = new ProductReviewVM
        //    {
        //        ReviewId = review.ReviewId,
        //        ProductId = review.ProductId,
        //        CustomerId = review.CustomerId,
        //        Comment = review.Comment,
        //        Rating = review.Rating

        //    };
        //   return View(reviewVM);

        //}
      
        //public IActionResult UpdateReview(ProductReviewVM model)
        //{

        //    if (ModelState.IsValid)
        //    {

        //        var Review = _db.Reviews.Where(x => x.ReviewId.Equals(model.ReviewId)).FirstOrDefault();
        //        if (Review != null)
        //        {
        //            Review.Comment = model.Comment;
        //            Review.Rating = model.Rating;
        //            _db.SaveChanges();
        //            return RedirectToAction("Index", "Order");
        //        }
           
              
        //    }
        //    return RedirectToAction("Index", "Order");
        //}
    }
}

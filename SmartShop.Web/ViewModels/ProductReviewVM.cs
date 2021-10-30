using SmartShop.DataLib.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Web.ViewModels
{
    public class ProductReviewVM
    {
         public int ReviewId { get; set; }
         [StringLength(300)]
         public string Comment { get; set; }
         [ForeignKey("Product")]
         public int ProductId { get; set; }
         [ForeignKey("Customer")]
         public int CustomerId { get; set; }
  
         public int Rating { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}

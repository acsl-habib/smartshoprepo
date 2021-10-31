using SmartShop.DataLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Web.ViewModels
{
    public class IndexVM
    {
        public ICollection<Product> Products { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
        public ICollection<Brand> Brands { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<ProductSpec> productSpecs { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

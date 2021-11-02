using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Edit
{
    public class ProductEditModel
    {
        public ProductEditModel()
        {
            

            this.ProductImages = new List<ProductImageEditModel>();
            this.ProductSpecs = new List<ProductSpecEditModel>();
            this.ProductPrices = new List<ProductPriceEditModel>();
          
        }
        public int ProductId { get; set; }

        [Required, StringLength(100)]
        public string ProductName { get; set; }

        [Required, StringLength(200)]
        public string ProductDescription { get; set; }

       
        [Required, StringLength(30)]
        public string PriceDeterminingProperty { get; set; }

        public bool? ProductStatus { get; set; }

        [Required]
        public int BrandId { get; set; }

        public int CategoryId { get; set; }
       
        public int SubcategoryId { get; set; }

        public virtual IList<ProductImageEditModel> ProductImages { get; set; }
        public virtual IList<ProductSpecEditModel> ProductSpecs { get; set; }
        public virtual IList<ProductPriceEditModel> ProductPrices { get; set; }
    }
}

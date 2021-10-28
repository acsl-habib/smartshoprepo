using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Input
{
    public class ProductAndPriceInputModel
    {
        public int ProductId { get; set; }

        [Required, StringLength(100)]
        public string ProductName { get; set; }

        [Required, StringLength(200)]
        public string ProductDescription { get; set; }

      
        [Required, StringLength(30)]
        public string PriceDeterminingProperty { get; set; }

        public bool ProductStatus { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int SubcategoryId { get; set; }

        public PriceInputModel[] PriceInputModels { get; set; }
    }
}

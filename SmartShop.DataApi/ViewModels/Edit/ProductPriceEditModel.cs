using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Edit
{
    public class ProductPriceEditModel
    {
        public int ProductPriceId { get; set; }
        [Required, StringLength(20)]
        public string PropertyValue { get; set; }
        [Required]
        public decimal Price { get; set; }
        //FK
        [Required]
        public int ProductId { get; set; }
    }
}

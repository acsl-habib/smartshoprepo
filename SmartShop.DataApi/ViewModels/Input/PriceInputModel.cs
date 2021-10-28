using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Input
{
    public class PriceInputModel
    {
        [Required, StringLength(20)]
        public string PropertyValue { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        
    }
}

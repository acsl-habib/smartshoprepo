using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Edit
{
    public class ProductImageEditModel
    {
        public int ProductImageId { get; set; }
        [Required, StringLength(150)]
        public string ImageName { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}

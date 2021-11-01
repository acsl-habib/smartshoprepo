using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Input
{
    public class CategoryInputModel
    {
        public int CategoryId { get; set; }
        [Required, StringLength(30)]
        public string CategoryName { get; set; }
        public string[] Subcategories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Edit
{
    public class SubcategoryEditModel
    {
        public int SubcategoryId { get; set; }
        [Required, StringLength(30)]
        public string SubcategoryName { get; set; }
        public int ProductCount { get; set; }
    }
}

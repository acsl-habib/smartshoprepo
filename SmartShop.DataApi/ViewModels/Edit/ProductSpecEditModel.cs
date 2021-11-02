using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Edit
{
    public class ProductSpecEditModel
    {
        public int ProductSpecId { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public bool IsChoosingLabel { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}

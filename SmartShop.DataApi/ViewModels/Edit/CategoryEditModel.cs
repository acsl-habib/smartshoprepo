using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Edit
{
    public class CategoryEditModel
    {
        public CategoryEditModel()
        {
            this.Subcategories = new List<SubcategoryEditModel>();
        }
        public int CategoryId { get; set; }
        [Required, StringLength(30)]
        public string CategoryName { get; set; }

        public ICollection<SubcategoryEditModel> Subcategories { get; set; }
    }
}

using SmartShop.DataLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Web.ViewModels
{
    public class CategoryVM
    {
        public ICollection<Category> Categories { get; set; }
    }
}

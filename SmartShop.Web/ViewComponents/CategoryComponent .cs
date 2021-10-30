using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShop.DataLib.Models.Data;
using SmartShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace SmartShop.Web.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        readonly SmartShopDbContext _db = null;

        public CategoryListViewComponent(SmartShopDbContext db)
        {
            this._db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {


            var Categories = _db.Categories.Include(x => x.Subcategories).ToList();


            var item = await Task.FromResult<CategoryVM>(new CategoryVM { Categories = Categories });
            return View(item);
        }
    }
}

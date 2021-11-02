using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShop.DataApi.ViewModels.Edit;
using SmartShop.DataApi.ViewModels.Input;
using SmartShop.DataLib.Models.Data;

namespace SmartShop.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Staff")]
    public class CategoriesController : ControllerBase
    {
        private readonly SmartShopDbContext _context;

        public CategoriesController(SmartShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        [HttpGet("Include")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesWithSubcategories()
        {
            return await _context
                .Categories
                .Include(x=> x.Subcategories)
                .ToListAsync();
        }
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }
        /*
         * Custom to get category edit model
         * 
         * */
        [HttpGet("{id}/ForEdit")]
        public async Task<ActionResult<CategoryEditModel>> GetCategoryForEdit(int id)
        {
            var category = await _context
                .Categories
                .Include(x=> x.Subcategories)
                .ThenInclude(x=> x.Products)
                .FirstOrDefaultAsync(c=> id== c.CategoryId);

            if (category == null)
            {
                return NotFound();
            }
            CategoryEditModel model = new CategoryEditModel { CategoryId = category.CategoryId, CategoryName = category.CategoryName };
            category.Subcategories.ToList().ForEach(s =>
            {
                model.Subcategories.Add(new SubcategoryEditModel
                {
                    SubcategoryId=s.SubcategoryId,
                    SubcategoryName=s.SubcategoryName,
                    ProductCount= s.Products.Count
                });
            });
            return model;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }
        /*
         * Custom to post category + subcategories
         * 
         * */
        [HttpPost("WithSubcategories")]
        public async Task<ActionResult<Category>> PostCategoryWithSubcateries(CategoryInputModel input)
        {
            var category = new Category { CategoryName = input.CategoryName };
            foreach(var s in input.Subcategories)
            {
                category.Subcategories.Add(new Subcategory { SubcategoryName = s });
            }
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }
        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }
        /*
         * Custom
         * 
         * */
        [HttpGet("{id}/Subcategories")]
        public async Task<IEnumerable<Subcategory>> GetSubcategories(int id /* category id */)
        {
            return await _context
                .Subcategories
                .Where(x => x.CategoryId == id)
                .ToListAsync();
        }
        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}

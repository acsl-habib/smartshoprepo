using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShop.DataLib.Models.Data;

namespace SmartShop.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin, Staff")]
    public class SubcategoriesController : ControllerBase
    {
        private readonly SmartShopDbContext _context;

        public SubcategoriesController(SmartShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Subcategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subcategory>>> GetSubcategories()
        {
            return await _context.Subcategories.ToListAsync();
        }
        [HttpGet("{id}/SpecLabels")]
        public async Task<IEnumerable<string>> GetSpecLabels(int id /* sub category id*/)
        {
            return await _context
                .ProductConfigurations
                .Where(x => x.SubcategoryId == id)
                .Select(x => x.ConfigurationLabel)
                .ToListAsync();

        }
        // GET: api/Subcategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subcategory>> GetSubcategory(int id)
        {
            var subcategory = await _context.Subcategories.FindAsync(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            return subcategory;
        }

        // PUT: api/Subcategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubcategory(int id, Subcategory subcategory)
        {
            if (id != subcategory.SubcategoryId)
            {
                return BadRequest();
            }

            _context.Entry(subcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubcategoryExists(id))
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

        // POST: api/Subcategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Subcategory>> PostSubcategory(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubcategory", new { id = subcategory.SubcategoryId }, subcategory);
        }

        // DELETE: api/Subcategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subcategory>> DeleteSubcategory(int id)
        {
            var subcategory = await _context.Subcategories.FindAsync(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            _context.Subcategories.Remove(subcategory);
            await _context.SaveChangesAsync();

            return subcategory;
        }

        private bool SubcategoryExists(int id)
        {
            return _context.Subcategories.Any(e => e.SubcategoryId == id);
        }
    }
}

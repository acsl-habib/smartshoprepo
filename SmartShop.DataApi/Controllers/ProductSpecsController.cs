using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShop.DataLib.Models.Data;

namespace SmartShop.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSpecsController : ControllerBase
    {
        private readonly SmartShopDbContext _context;

        public ProductSpecsController(SmartShopDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductSpecs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSpec>>> GetProductSpecs()
        {
            return await _context.ProductSpecs.ToListAsync();
        }

        // GET: api/ProductSpecs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSpec>> GetProductSpec(int id)
        {
            var productSpec = await _context.ProductSpecs.FindAsync(id);

            if (productSpec == null)
            {
                return NotFound();
            }

            return productSpec;
        }

        // PUT: api/ProductSpecs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSpec(int id, ProductSpec productSpec)
        {
            if (id != productSpec.ProductSpecId)
            {
                return BadRequest();
            }

            _context.Entry(productSpec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSpecExists(id))
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

        // POST: api/ProductSpecs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductSpec>> PostProductSpec(ProductSpec productSpec)
        {
            _context.ProductSpecs.Add(productSpec);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductSpec", new { id = productSpec.ProductSpecId }, productSpec);
        }

        // DELETE: api/ProductSpecs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductSpec>> DeleteProductSpec(int id)
        {
            var productSpec = await _context.ProductSpecs.FindAsync(id);
            if (productSpec == null)
            {
                return NotFound();
            }

            _context.ProductSpecs.Remove(productSpec);
            await _context.SaveChangesAsync();

            return productSpec;
        }

        private bool ProductSpecExists(int id)
        {
            return _context.ProductSpecs.Any(e => e.ProductSpecId == id);
        }
    }
}

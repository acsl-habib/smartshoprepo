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
    [Authorize(Roles = "Admin")]
    public class ProductConfigurationsController : ControllerBase
    {
        private readonly SmartShopDbContext _context;

        public ProductConfigurationsController(SmartShopDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductConfigurations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductConfiguration>>> GetProductConfigurations()
        {
            return await _context.ProductConfigurations.ToListAsync();
        }

        // GET: api/ProductConfigurations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductConfiguration>> GetProductConfiguration(int id)
        {
            var productConfiguration = await _context.ProductConfigurations.FindAsync(id);

            if (productConfiguration == null)
            {
                return NotFound();
            }

            return productConfiguration;
        }

        // PUT: api/ProductConfigurations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductConfiguration(int id, ProductConfiguration productConfiguration)
        {
            if (id != productConfiguration.ProductConfigurationId)
            {
                return BadRequest();
            }

            _context.Entry(productConfiguration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductConfigurationExists(id))
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

        // POST: api/ProductConfigurations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductConfiguration>> PostProductConfiguration(ProductConfiguration productConfiguration)
        {
            _context.ProductConfigurations.Add(productConfiguration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductConfiguration", new { id = productConfiguration.ProductConfigurationId }, productConfiguration);
        }

        // DELETE: api/ProductConfigurations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductConfiguration>> DeleteProductConfiguration(int id)
        {
            var productConfiguration = await _context.ProductConfigurations.FindAsync(id);
            if (productConfiguration == null)
            {
                return NotFound();
            }

            _context.ProductConfigurations.Remove(productConfiguration);
            await _context.SaveChangesAsync();

            return productConfiguration;
        }

        private bool ProductConfigurationExists(int id)
        {
            return _context.ProductConfigurations.Any(e => e.ProductConfigurationId == id);
        }
    }
}

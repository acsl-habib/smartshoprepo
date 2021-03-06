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
    public class ProductsController : ControllerBase
    {
        private readonly SmartShopDbContext _context;

        public ProductsController(SmartShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        /*
         * Custom
         * 
         * */
        [HttpGet("Include")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsIncludeAll()
        {
            return await _context
                .Products
                .Include(x=> x.ProductImages)
                .Include(x=> x.ProductSizes)
                .Include(x=> x.ProductColors)
                .ToListAsync();
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
        /*
         * Custom
         * 
         * */
        // api/Products/5/Sizes
        [HttpGet("{id}/Sizes")]
        public async Task<ActionResult<IEnumerable<ProductSize>>> GetSizes(int id /* product id */)
        {
            return await _context
                .ProductSizes
                .Where(x => x.ProductId == id)
                .ToListAsync();
        }
        [HttpGet("{id}/Colors")]
        public async Task<ActionResult<IEnumerable<ProductColor>>> GetColors(int id /* product id */)
        {
            return await _context
                .ProductColors
                .Where(x => x.ProductId == id)
                .ToListAsync();
        }
        [HttpGet("{id}/Images")]
        public async Task<ActionResult<IEnumerable<ProductImage>>> GetIamgess(int id /* product id */)
        {
            return await _context
                .ProductImages
                .Where(x => x.ProductId == id)
                .ToListAsync();
        }
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}

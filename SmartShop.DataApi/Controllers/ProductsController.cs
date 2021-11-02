using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsWithPriceAndPic()
        {
            return await _context
                .Products
                .Include(x=> x.ProductPrices)
                .Include(x=> x.ProductImages)
                .ToListAsync();
        }
        [HttpGet("{id}/Include")]
        public async Task<ActionResult<Product>> GetProductWithPriceAndPic(int id)
        {
            return await _context
                .Products
                .Include(x => x.ProductPrices)
                .Include(x => x.ProductImages)
                .Include(x=> x.ProductSpecs)
                .FirstOrDefaultAsync(x => x.ProductId == id);
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
        [HttpGet("{id}/ForEdit")]
        public async Task<ActionResult<ProductEditModel>> GetProductForEdit(int id)
        {
            var product = await 
                _context
                .Products
                .Include(x=> x.Subcategory)               
                .Include(x => x.ProductPrices)
                .Include(x => x.ProductImages)
                .Include(x => x.ProductSpecs)
                .FirstOrDefaultAsync(x=> x.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductEditModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                PriceDeterminingProperty = product.PriceDeterminingProperty,
                ProductStatus = product.ProductStatus,
                BrandId = product.BrandId,
                CategoryId=product.Subcategory.CategoryId,
                SubcategoryId = product.SubcategoryId.Value
            };
            product.ProductPrices.ToList().ForEach(p =>
            {
                model.ProductPrices.Add(new ProductPriceEditModel { PropertyValue = p.PropertyValue, Price = p.Price, ProductPriceId=p.ProductPriceId });
            });
            product.ProductSpecs.ToList().ForEach(p =>
            {
                model.ProductSpecs.Add(new ProductSpecEditModel {ProductSpecId=p.ProductSpecId, IsChoosingLabel=p.IsChoosingLabel, Label=p.Label, Value=p.Value});
            });
            product.ProductImages.ToList().ForEach(p =>
            {
                model.ProductImages.Add(new ProductImageEditModel { ProductImageId=p.ProductImageId, ImageName=p.ImageName});
            });
            return model;
        }
        /*
         * Custom to get determining property 
         * 
         * */
        [HttpGet("PropNames")]
        public async Task<IEnumerable<string>> GetPropertNames()
        {
            return await _context
                            .Products
                            .Select(x => x.PriceDeterminingProperty)
                            .Where(x => x.ToLower() != "none")
                            .Distinct()
                            .ToListAsync();
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
        /*
         * Custom: Save product and price
         * 
         * */
        [HttpPost("WithPrice")]
        public async Task<ActionResult<Product>> PostProductAndPrice(ProductAndPriceInputModel data)
        {
            var product = new Product {
                ProductName = data.ProductName,
                BrandId = data.BrandId,
                ProductDescription = data.ProductDescription,
                ProductStatus=data.ProductStatus,
                SubcategoryId=data.SubcategoryId,
                PriceDeterminingProperty=data.PriceDeterminingProperty
            };
            foreach(var p in data.PriceInputModels)
            {
                product.ProductPrices.Add(new ProductPrice { PropertyValue = p.PropertyValue, Price = p.Price });
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }
        [HttpPost("Specs")]
        public async Task<ActionResult> PostSpecs(ProductConfigInputModel model)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == model.ProductId);
            foreach (var sp in model.Specs)
            {
                if (product != null)
                {
                    if (!_context.ProductConfigurations.Any(x =>
                        x.SubcategoryId == product.SubcategoryId
                        && x.ConfigurationLabel.ToLower() == sp.Label.ToLower()
                    ))
                    {
                        _context.ProductConfigurations.Add(new ProductConfiguration { SubcategoryId = product.SubcategoryId.Value, ConfigurationLabel = sp.Label });
                    }
                }
                var temp =new ProductSpec { ProductId = model.ProductId, Label = sp.Label, Value = sp.Value, IsChoosingLabel = true };
                _context.ProductSpecs.Add(temp);
            }
            await _context.SaveChangesAsync();
            
            return Ok();
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

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}

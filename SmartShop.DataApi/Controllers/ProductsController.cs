﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                //.Include(x=> x.ProductImages)
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

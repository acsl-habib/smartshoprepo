using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartShop.DataApi.ViewModels.Data;
using SmartShop.DataLib.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly SmartShopDbContext db;
        public ImagesController(IWebHostEnvironment env, SmartShopDbContext db)
        {
            this.env = env;
            this.db = db;
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<ImagePathResponse>> PostImage(int id, IFormFile file)
        {
            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            try
            {
                string ext = Path.GetExtension(file.FileName);
                string f = Guid.NewGuid() + ext;
                if (!Directory.Exists(env.WebRootPath + "\\Iamges\\"))
                {
                    Directory.CreateDirectory(env.WebRootPath + "\\Images\\");
                }
                using FileStream filestream = System.IO.File.Create(env.WebRootPath + "\\Images\\" + f);
              
                    file.CopyTo(filestream);
                    filestream.Flush();
                    product.ProductImages.Add(new ProductImage { ImageName = f });
                    await db.SaveChangesAsync();
                    filestream.Close();
                    return new ImagePathResponse { ImagePath =  f };
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

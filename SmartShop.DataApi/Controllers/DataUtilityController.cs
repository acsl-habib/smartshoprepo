using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using SmartShop.DataLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class DataUtilityController : ControllerBase
    {
        public readonly SmartShopDbContext db;
        public DataUtilityController(SmartShopDbContext db) { this.db = db; }
        [HttpGet("Status")]
        public async Task<ActionResult<bool>> DbStatus()
        {
            return await this.db.Database.CanConnectAsync();
        }
        [HttpPost("Migrate")]
        public async Task<ActionResult> MigrateDb()
        {
              await db.GetInfrastructure().GetService<IMigrator>().MigrateAsync("SmartShop_V2");
              return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using SmartShop.DataApi.ViewModels.Identity;
using SmartShop.DataLib.Models.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration config;
        public readonly SmartShopDbContext db;
        public AccountController(UserManager<IdentityUser> userManager, IConfiguration config, SmartShopDbContext db)
        {
            this.userManager = userManager;
            this.config = config;
            this.db = db;
        }
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            
            //Thread.Sleep(2000);
            var user = await userManager.FindByNameAsync(model.Username.ToUpper());

            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var roles = await userManager.GetRolesAsync(user);
                var signingKey =
                  Encoding.UTF8.GetBytes(config["Jwt:SigningKey"]);
                var expiryDuration = int.Parse(config["Jwt:ExpiryInMinutes"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = null,              // Not required as no third-party is involved
                    Audience = null,            // Not required as no third-party is involved
                    IssuedAt = DateTime.UtcNow,
                    NotBefore = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddMinutes(expiryDuration),
                    Subject = new ClaimsIdentity(new List<Claim> {
                        new Claim("username",user.UserName),
                        new Claim("role", string.Join(",", roles)),
                        new Claim("expires", DateTime.UtcNow.AddMinutes(expiryDuration).ToString("yyyy-MM-ddTHH:mm:ss"))
                    }
                    ),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
                var token = jwtTokenHandler.WriteToken(jwtToken);
                return Ok(
                  new
                  {
                      token,
                      expiration = jwtToken.ValidTo,
                      refreshToken = user.Id
                  });
            }
            return BadRequest();
        }
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Staff");
            }
            return Ok(new { Username = user.UserName });
        }
        [Route("customer/register")]
        [HttpPost]
        public async Task<ActionResult> RegisterCustomer(RegisterViewModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Customer");
                await db.Customers.AddAsync(new Customer { UserId = user.Id });
            }
            return Ok(new { Username = user.UserName });
        }
        [Route("RefreshToken/{id}")]
        [HttpPost]
        public async Task<ActionResult> Login(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                var roles = await userManager.GetRolesAsync(user);
                var signingKey =
                  Encoding.UTF8.GetBytes(config["Jwt:SigningKey"]);
                var expiryDuration = int.Parse(config["Jwt:ExpiryInMinutes"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = null,              // Not required as no third-party is involved
                    Audience = null,            // Not required as no third-party is involved
                    IssuedAt = DateTime.UtcNow,
                    NotBefore = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddMinutes(expiryDuration),
                    Subject = new ClaimsIdentity(new List<Claim> {
                        new Claim("username", user.UserName),
                        new Claim("role",string.Join(',',roles))
                    }
                    ),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
                var token = jwtTokenHandler.WriteToken(jwtToken);
                return Ok(
                  new
                  {
                      token,
                      expiration = jwtToken.ValidTo,
                      refreshToken = user.Id
                  });
            }
            return Unauthorized();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartShop.DataApi.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class UserDataController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        public UserDataController(UserManager<IdentityUser> userManager) { this.userManager = userManager; }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDataViewModel>>> GetUsers()
        {
            List<UserDataViewModel> users = new List<UserDataViewModel>();
            var data = this.userManager.Users.ToList();
            foreach(var u in data)
            {
                var r = await userManager.GetRolesAsync(u);
                users.Add(new UserDataViewModel { Id = u.Id, Username = u.UserName, Email = u.Email, Roles = r.ToArray() });
            }
            return users;
        }
    }
}

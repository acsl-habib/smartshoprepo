
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartShop.DataLib.Models.Data;
using SmartShop.Web.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartShop.Web.Controllers
{

    public class CustomerController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        readonly SmartShopDbContext db = null;

        public CustomerController(UserManager<IdentityUser> userManager,
                                       SignInManager<IdentityUser> signInManager, SmartShopDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        //register page
        public IActionResult Register()
        {
            return View();
        }

        //register customer

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await _userManager.CreateAsync(user, model.Password);



                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    await _userManager.AddToRoleAsync(user, "Customer");
                    var customer = new Customer()
                    {
                        UserId = user.Id,
                    };
                    await db.Customers.AddAsync(customer);
                    await db.SaveChangesAsync();



                    await _signInManager.SignInAsync(user, isPersistent: false);


                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }

        //login page controller
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        //login controller
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, true, false);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "User");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }



        //logout controller

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}

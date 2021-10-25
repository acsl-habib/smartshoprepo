using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.Controllers
{
    //[Route("data/[controller]")]
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
           
            return View();
        }
        
        public IActionResult Test()
        {
            return View();
        }
    }
}

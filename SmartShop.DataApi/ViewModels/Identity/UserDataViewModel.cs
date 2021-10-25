using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Identity
{
    public class UserDataViewModel
    {
       
        public string Id { get; set; }
        [Required, StringLength(30)]
        public string Username { get; set; }
        [Required, StringLength(50), EmailAddress]
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}

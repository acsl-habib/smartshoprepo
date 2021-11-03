using SmartShop.DataLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Web.ViewModels
{
    public class OrderVM
    {
        public ICollection<Order> Orders { get; set; }

        public decimal Total { get; set; }
        public virtual Customer Customer { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
   
    }
}

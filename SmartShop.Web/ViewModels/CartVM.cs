using SmartShop.DataLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Web.ViewModels
{
    public class CartVM
    {
        public ICollection<Cart> Carts { get; set; }
        public decimal Total { get; set; }
        public int Quantity { get; set; }
        public int ProductPrice { get; set; }

    }
}

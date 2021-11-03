using SmartShop.DataLib.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Web.ViewModels
{
    public class CheckoutVM
    {
        public Customer Customer { get; set; }
        public ICollection<Shipping> Shipping { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Cart> Carts { get; set; }

        public decimal Total { get; set; }
        [StringLength(200)]
        public string Message { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
       public int ShippingId { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public string PaymentName { get; set; }
        public int PaymentId { get; set; }
        public string TrxId { get; set; }
    }
}

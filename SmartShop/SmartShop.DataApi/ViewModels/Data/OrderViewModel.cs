
using SmartShop.DataLib.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Data
{
    public class OrderViewModel
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DeliveryDate { get; set; }
        public int CampaignId { get; set; }
        public OrderDetail[] OrderDetail { get; set; }
    }
}

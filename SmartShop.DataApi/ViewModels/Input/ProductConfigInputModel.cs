using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Input
{
    public class ProductConfigInputModel
    {
        public int ProductId { get; set; }
        public SpecInputModel[] Specs { get; set; }
    }
}

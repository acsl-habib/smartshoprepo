using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.DataApi.ViewModels.Data
{
    public class ImagePathResponse
    {
        public int ProductImageId { get; set; }

        public string ImagePath { get; set; }

        public int ProductId { get; set; }
    }
}

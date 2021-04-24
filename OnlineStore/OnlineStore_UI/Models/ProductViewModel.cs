using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore_UI.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductProperties = new List<ProductPropertiesViewModel>();
        }
        public int Cost { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int Discount { get; set; }
        public int Count { get; set; }
        public string Category { get; set; }
        public int CountProperties { get; set; }
        public string Description { get; set; }
        public IList<ProductPropertiesViewModel> ProductProperties { get; set; }
    }
}

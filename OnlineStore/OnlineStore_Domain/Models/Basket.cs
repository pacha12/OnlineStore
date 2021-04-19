using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_Domain.Models
{
    public class Basket
    {
        public Basket()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public IList<Product> Products { get; set; }
    }
}

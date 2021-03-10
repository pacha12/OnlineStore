using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IList<Product> Products { get; set; }
        public DateTime SaleDate { get; set; }
    }
}

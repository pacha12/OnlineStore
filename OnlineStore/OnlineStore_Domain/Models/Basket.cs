using OnlineStore_Domain.Models.Identity;
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
            BasketItems = new List<BasketItem>();
        }
        public int Id { get; set; }
        public IList<BasketItem> BasketItems { get; set; }
        public User User { get; set; }
    }
}

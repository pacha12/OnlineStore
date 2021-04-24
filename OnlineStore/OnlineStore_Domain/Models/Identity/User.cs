using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_Domain.Models.Identity
{
    public class User:IdentityUser<Guid>
    {
        public User()
        {
            Orders = new List<Order>();
            Histories = new List<History>();
        }
        public decimal Money { get; set; }
        public IList<Order> Orders { get; set; }
        public decimal Bonuses { get; set; }
        public Basket Basket { get; set; }
        public int BasketId { get; set; }
        public IList<History> Histories { get; set; }
    }
}

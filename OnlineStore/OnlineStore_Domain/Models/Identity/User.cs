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
        public decimal Money { get; set; }
        public IList<Order> Orders { get; set; }
        public decimal Bonuses { get; set; }
    }
}

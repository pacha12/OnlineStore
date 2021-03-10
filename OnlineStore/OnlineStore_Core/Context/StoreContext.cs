using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStore_Domain.Models;
using OnlineStore_Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_Core.Context
{
    public class StoreContext : IdentityDbContext<User, Role, Guid>
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
        DbSet<Product> Products { get; set; }
        DbSet<ProductProperties> ProductProperties { get; set; }
    }
}

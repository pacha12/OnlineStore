using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore_Core.Context;
using OnlineStore_Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_BLL.Infrastructure
{
    public class BLLConfiguration
    {
        public static void Configuration(IServiceCollection collection, string dbConnection)
        {
            collection.AddDbContext<StoreContext>(x => x.UseSqlServer(dbConnection));
            collection.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<StoreContext>().AddDefaultTokenProviders();



        }
    }
}

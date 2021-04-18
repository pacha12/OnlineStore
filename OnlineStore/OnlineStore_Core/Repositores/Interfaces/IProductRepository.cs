using OnlineStore_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_Core.Repositores.Interfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<IQueryable<Product>> GetProductsAsync();
        Task<IQueryable<Product>> GetProductsAsync(string category);
    }
}

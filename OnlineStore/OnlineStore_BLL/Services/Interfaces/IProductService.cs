using OnlineStore_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(Product product);
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsAsync(string category);
    }
}

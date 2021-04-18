using OnlineStore_Core.Context;
using OnlineStore_Core.Repositores.Interfaces;
using OnlineStore_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_Core.Repositores
{
    public class ProductRepository:IProductRepository
    {
        private readonly StoreContext _db;
        public ProductRepository(StoreContext _db)
        {
            this._db = _db;
        }
        public async Task AddProductAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }
        public async Task<IQueryable<Product>> GetProductsAsync()
        {
            var tmp = _db.Products;
            return tmp;
        }
        public async Task<IQueryable<Product>> GetProductsAsync(string category)
        {
            var tmp = _db.Products.Where(x => x.Category == category);
            return tmp;
        }
    }
}

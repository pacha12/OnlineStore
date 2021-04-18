using OnlineStore_BLL.Services.Interfaces;
using OnlineStore_Core.Repositores;
using OnlineStore_Core.Repositores.Interfaces;
using OnlineStore_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_BLL.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository _productRepository)
        {
            this._productRepository = _productRepository;
        }
        public async Task AddProductAsync(Product product)
        {
            _productRepository.AddProductAsync(product);
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            var tmp = await _productRepository.GetProductsAsync();
            return  tmp.ToList();
        }
        public async Task<List<Product>> GetProductsAsync(string category)
        {
            var tmp = await _productRepository.GetProductsAsync(category);
            return tmp.ToList();
        }
    }
}

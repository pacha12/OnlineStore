using Microsoft.AspNetCore.Mvc;
using OnlineStore_BLL.Services;
using OnlineStore_BLL.Services.Interfaces;
using OnlineStore_Domain.Models;
using OnlineStore_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService _productService)
        {
            this._productService = _productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetProducts(string category)
        {
            List<Product> products;
            if (category != null)
            {
                products = await _productService.GetProductsAsync(category);
            }
            else
            {
                products = await _productService.GetProductsAsync();
            }

            return PartialView("ProductsView", products);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            List<string> categoryes = new List<string>();
            var dbCategory = _productService.GetProductsAsync().Result;
            categoryes.Add(dbCategory[0].Category);
            foreach(var product in dbCategory)
            {
                int tmp = 0;
                foreach (var category in categoryes)
                {
                    if (category == product.Category) tmp++;
                }
                if (tmp == 0) categoryes.Add(product.Category);
            }
            return PartialView("CategoryesView", categoryes);
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult ProductAdd()
        {
           return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ProductAdd(Product product)
        {
            product.ProductProperties = new List<ProductProperties>();
            product.Reviews = new List<Review>();
            product.ProductProperties.Add(new ProductProperties() { Name = "Power", Value = "3000" });
            await _productService.AddProductAsync(product);
            return Redirect("ProductView");
        }
    }
}
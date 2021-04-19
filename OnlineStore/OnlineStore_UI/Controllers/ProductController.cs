using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore_BLL.Services;
using OnlineStore_BLL.Services.Interfaces;
using OnlineStore_Domain.Models;
using OnlineStore_Domain.Models.Identity;
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
        private readonly UserManager<User> _userManager;
        public ProductController(IProductService _productService, UserManager<User> userManager)
        {
            this._userManager = userManager;
            this._productService = _productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
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
            foreach (var product in dbCategory)
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
       
        public async Task<IActionResult> GetSearchProducts(string search)
        {
            List<Product> products = new List<Product>();
            foreach (var product in _productService.GetProductsAsync().Result)
            {
                if (product.ProductProperties != null)
                {
                    foreach (var item in product.ProductProperties)
                    {
                        if (item.Value == search)
                        {
                            products.Add(product);
                            break;
                        }
                        else if (product.Name == search)
                        {
                            products.Add(product);
                            break;
                        }
                    }
                }
                else
                {
                    if (product.Name == search) products.Add(product);
                }
               
            }
            return PartialView("ProductsView", products);
        }
        [Authorize]
        public async Task<IActionResult> GetBasket()
        {
            var users =_userManager.Users.Include(x => x.Basket).Include(x=>x.Basket.Products);
            var tmp = users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            return PartialView("GetBasket", tmp);
        }
        public async Task<IActionResult> AboutProduct(int productId)
        {
            var tmp = _productService.GetProductsAsync().Result.FirstOrDefault(x => x.Id == productId);
            tmp.ProductProperties.Add(new ProductProperties() { Name = "Some name", Value = "Some Val" });
            tmp.ProductProperties.Add(new ProductProperties() { Name = "Some name", Value = "Some Val" });
            tmp.ProductProperties.Add(new ProductProperties() { Name = "Some name", Value = "Some Val" });
            tmp.ProductProperties.Add(new ProductProperties() { Name = "Some name", Value = "Some Val" });
            tmp.ProductProperties.Add(new ProductProperties() { Name = "Some name", Value = "Some Val" });
            return PartialView("AboutProduct", tmp);
        }
    }
}
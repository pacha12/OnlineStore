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
            List<Product> products = new List<Product>();
            if (category != null)
            {
                products = await _productService.GetProductsAsync(category);
            }
            else
            {
                int indexcategory = 0;
                var dbProducts = await _productService.GetProductsAsync();
                products.Add(dbProducts[0]);
               foreach(var dbProduct in dbProducts)
                {
                    foreach(var product in products)
                    {
                        if (product.Category == dbProduct.Category) indexcategory++;
                    }
                    if (indexcategory == 0) products.Add(dbProduct);
                    indexcategory = 0;
                }
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

                    }
                }
                else if (product.Name == search)
                {
                    products.Add(product);
                    break;
                }
                else if (product.Category == search)
                {
                    products.Add(product);
                    break;
                }

            }
            return PartialView("ProductsView", products);
        }
        [Authorize]
        public async Task<IActionResult> GetBasket()
        {
            var users = _userManager.Users.Include(x => x.Basket).Include(x => x.Basket.BasketItems);
            var tmp = users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            return PartialView("GetBasket", tmp);
        }
        public async Task<IActionResult> AboutProduct(int productId)
        {
            var tmp = _productService.GetProductsAsync().Result.FirstOrDefault(x => x.Id == productId);
            return PartialView("AboutProduct", tmp);
        }
    }
}
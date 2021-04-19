using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore_BLL.Services.Interfaces;
using OnlineStore_Domain.Models;
using OnlineStore_Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore_UI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<User> _userManager;
        public AdminController(IProductService productService, UserManager<User> userManager)
        {
            _productService = productService;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd(Product product)
        {
            await _productService.AddProductAsync(product);
            return Redirect("/home/index");
        }

    }
}

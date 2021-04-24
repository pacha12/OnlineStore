using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public AdminController(IProductService productService, UserManager<User> userManager, IMapper mapper)
        {
            _productService = productService;
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductViewModel product)
        {
            if (product.CountProperties == 0)
            {
                await _productService.AddProductAsync(_mapper.Map<ProductViewModel, Product>(product));
                return Redirect("/home/index");
            }
            else
            {
                return View("ProductAddProperties", product);
            }
        }
        public async Task<IActionResult> ProductAddWithProperties(List<string> ProductPropertiesName, List<string> ProductPropertiesValue, ProductViewModel product)
        {
            for (int i = 0; i < ProductPropertiesName.Count; i++) 
            {
                product.ProductProperties.Add(new ProductPropertiesViewModel() { Name = ProductPropertiesName[i], Value = ProductPropertiesValue[i] });
            }
            await _productService.AddProductAsync((_mapper.Map<ProductViewModel, Product>(product)));
            return Redirect("home/index");
        }
    }
}

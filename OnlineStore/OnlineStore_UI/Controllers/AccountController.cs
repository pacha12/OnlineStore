using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore_Domain.Models.Identity;
using OnlineStore_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore_UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register(string returnUrl = "") => View();


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = "")
        {
            if (!TryValidateModel(model)) return StatusCode(500);

            var user = new User() { Email = model.Login, UserName = model.Login, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return StatusCode(500);

            if (await _roleManager.FindByNameAsync("user") == null)
            {
                var role = await _roleManager.CreateAsync(new Role() { Name = "user" });
                if (role.Succeeded)
                    await _userManager.AddToRoleAsync(user, "user");
            }
            else await _userManager.AddToRoleAsync(user, "user");

            await _signInManager.SignInAsync(user, false);

            return Redirect("/home/index");

        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = "") => View();



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "")
        {
            if (!TryValidateModel(model)) return StatusCode(500);

            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return StatusCode(500);

        }
        //[HttpPost] 
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = "")
        {
            await _signInManager.SignOutAsync();
            if (returnUrl == "/") return RedirectToAction("Index", "Home");
            else if (Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
            return RedirectToAction("Login", "Account");
        }
    }
}

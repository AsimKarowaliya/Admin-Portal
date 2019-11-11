using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin_Portal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Portal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {

            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);


                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Home");
                }


                ModelState.AddModelError("", "Invalid Login Attempt");

                return View(login);
            }

            return View(login);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = register.Email, Email = register.Email};
                var result = await _userManager.CreateAsync(user, register.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
            }
            return View();
        }
    }
}
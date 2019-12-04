using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Admin_Portal.Models;
using Microsoft.AspNetCore.Identity;

namespace Admin_Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly DataBaseContext dataBaseContext;
        public HomeController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, DataBaseContext dataBaseContext)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.dataBaseContext = dataBaseContext;
        }
        [HttpGet]
        public IActionResult Index(Link home)
        {

            var list1 = dataBaseContext.links.Where(s => s.RoleName.StartsWith("Admin")).ToList();
            var list2 = dataBaseContext.links.Where(s => s.RoleName.StartsWith("Finance")).ToList();
            var list3 = dataBaseContext.links.Where(s => s.RoleName.StartsWith("Sales")).ToList();
            var list4 = dataBaseContext.links.Where(s => s.RoleName.StartsWith("Hr")).ToList();
            var list5 = dataBaseContext.links.Where(s => s.RoleName.StartsWith("Engg")).ToList();
            ViewBag.Admin = list1;
            ViewBag.Finance = list2;
            ViewBag.Sales = list3;
            ViewBag.Hr = list4;
            ViewBag.Engg = list5;
            //ViewBag.Admin = list;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

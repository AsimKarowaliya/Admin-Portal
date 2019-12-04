using Admin_Portal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Portal.Controllers
{
    [Authorize(Roles = "SuperAdmin")]

    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly DataBaseContext dataBaseContext;
        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, DataBaseContext dataBaseContext)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.dataBaseContext = dataBaseContext;
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }else
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListRoles");
            }
        }
        [HttpGet]
        public IActionResult AddLink()
        {

            var vm = new Link();

            var roles = roleManager.Roles.ToList();

            vm.selectLists = roles.Select(r => new SelectListItem { Value = r.Id, Text = r.Name });

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddLink(Link links)
        {



            var id = links.Roles.Id;

            var ddlist = dataBaseContext.Roles.Find(id);

        

            links.RoleName = ddlist.Name;

            var seletedName = links.selectLists;

           dataBaseContext.links.Add(links);

            dataBaseContext.SaveChanges();
            return RedirectToAction("ListRoles", "Administration");
        }

        [HttpGet]
        public IActionResult RemoveLinks()
        {


            var vm = new Link();

            var roles = roleManager.Roles.ToList();
            var links = dataBaseContext.links.ToList();
            vm.selectLists = links.Select(r => new SelectListItem { Value = r.ID, Text = r.LinkName });

            return View(vm);
        }

        [HttpPost]
        public IActionResult RemoveLinks(Link links)
        {
            var id = links.Roles.Id;

            var ddlist = dataBaseContext.links.Find(id);



          

         

            dataBaseContext.links.Remove(ddlist);

            dataBaseContext.SaveChanges();

            return RedirectToAction("ListRoles", "Administration");
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;

            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id= {Id} cannot be found";
                return View("NotFound");
            }
            var model = new EditRoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name,
            };

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel Model)
        {
            var role = await roleManager.FindByIdAsync(Model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id= {Model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = Model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(Model);
            }





        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";

                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var UserRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName

                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    UserRoleViewModel.IsSelected = true;
                }
                else
                {
                    UserRoleViewModel.IsSelected = false;
                }

                model.Add(UserRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result;
                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && (await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", new { Id = roleId });
                    }
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });

        }
    }
}
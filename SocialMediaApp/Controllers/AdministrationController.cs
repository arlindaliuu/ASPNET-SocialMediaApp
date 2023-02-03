using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;
using SocialMediaApp.ViewModels;
using System.Data;

namespace SocialMediaApp.Controllers
{
    public class AdministrationController : Controller
    {
     private readonly RoleManager<IdentityRole> roleManager;
     public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;

        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {

            if (!await roleManager.RoleExistsAsync(roleName))
            {
                if (!String.IsNullOrEmpty(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            return RedirectToAction("index", "home");
        }
    }
}

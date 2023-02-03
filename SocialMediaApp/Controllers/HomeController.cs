using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Configuration;
using SocialMediaApp.Models;
using System.Diagnostics;

namespace SocialMediaApp.Controllers
{
    
    public class HomeController : Controller
    {
        private SocialNetworkDbContext _application;    
        private readonly ILogger<HomeController> _logger;
        private UserManager<User> _userManager { get; set; }

        public HomeController(SocialNetworkDbContext application,ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _application = application;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.userid = _userManager.GetUserName(HttpContext.User);
            return View();
        }

        public IActionResult Privacy()
        {
            return View(_application.Users.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
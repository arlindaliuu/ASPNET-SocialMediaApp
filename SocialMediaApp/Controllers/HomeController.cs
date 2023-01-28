using Microsoft.AspNetCore.Authorization;
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

        public HomeController(SocialNetworkDbContext application,ILogger<HomeController> logger)
        {
            _application = application;
            _logger = logger;
        }

        public IActionResult Index()
        {
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
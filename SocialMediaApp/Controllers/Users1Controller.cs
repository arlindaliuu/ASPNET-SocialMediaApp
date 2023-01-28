/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Configuration;
using SocialMediaApp.Models;

namespace SocialMediaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users1Controller : ControllerBase
    {
        private readonly SocialNetworkDbContext _context;
        private UserManager<User> _userManager { get; set; }


        public Users1Controller(SocialNetworkDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: api/Posts1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetPosts()
        {
            return await _userManager.Users.ToList();
        }
    }

}
*/
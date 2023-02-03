using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Configuration;
using SocialMediaApp.Models;
using SocialMediaApp.ViewModels;
using System.Security.Claims;

namespace SocialMediaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SocialNetworkDbContext _context;
        private UserManager<User> _userManager { get; set; }
        private IAuthentication auth { get; set; }
        private SignInManager<User> _signInManager { get; set; }
/*        private RoleManager<User> _roleManager { get; set; }
*/
    public AuthenticationController(SocialNetworkDbContext context, UserManager<User> userManager, SignInManager<User> signInManager, IAuthentication auth)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            this.auth = auth;
/*            _roleManager = roleManager;
*/        }
       

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var res = await this._signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (res.Succeeded)
                {
                    
                    return Ok(auth.Authenticate(model.Email));
                }
            }
            return Unauthorized();
        }
/*        [HttpGet("users")]
        public string GetUser()
        {
            var userName = _userManager.GetUserName(HttpContext.User);
            return userName;
        }*/
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid && model.Password == model.ConfirmPassword)
            {

                User user = new User();
                user.first_name = model.first_name;
                user.last_name = model.last_name;
                user.date_created = DateTime.Now;
                user.UserName = model.UserName; 
                user.date_updated = model.date_updated;
                user.birth_date = model.birth_date;
                user.active = model.active;
                user.activation_key = model.activation_key;
                user.country = model.country;
                user.city = model.city;
                user.state = model.state;
                user.gender = model.gender;
                user.profile_picture_url = model.profile_picture_url;
                user.Email = model.Email;




                /*var userAdded = _context.Users.Add(user);*/
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var newUser = new RegisteredUserViewModel();
                    newUser.first_name = user.first_name;
                    newUser.last_name = user.last_name;
                    newUser.date_updated = user.date_updated;
                    newUser.country = user.country;
                    newUser.UserName = user.UserName;
                    newUser.birth_date = user.birth_date;
                    newUser.city = user.city;
                    newUser.Email = user.Email;
                    newUser.date_created = user.date_created;
                    newUser.gender = user.gender;
                    newUser.profile_picture_url = user.profile_picture_url;
                    return Ok(newUser);
                }
              /*      this._context.SaveChanges();

                var currentUser = this._userManager.FindByIdAsync(userAdded.Entity.Id);

                this._userManager.AddToRoleAsync(currentUser.Result, "Administrator");*/
                
            }

            return BadRequest("Registration has failed!");
        }
        [HttpGet]
        [Route("Users")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok("You have this");
        }
        [HttpGet]
        [Route("Users/{id}")]
        public async Task<IActionResult> GetUserId(int id)
        {
            return Ok(new { userID = id });
        }

        [HttpGet]
        [Route("Users/current")]
        public async Task<IActionResult> getLoggedInUserId()
        {
            int id = Convert.ToInt32(HttpContext.User.FindFirstValue("userID"));
            return Ok(new { userId = id });
        }

        [Authorize]
        public IActionResult GetPosts()
        {
            var data = this._context.Posts.ToList();
            return Ok(data);
        }
    }
}

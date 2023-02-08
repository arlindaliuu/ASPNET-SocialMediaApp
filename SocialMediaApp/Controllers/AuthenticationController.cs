using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Configuration;
using SocialMediaApp.Models;
using SocialMediaApp.ViewModels;
using System.Net;
using System.Security.Claims;
using AuthorizeAttribute = SocialMediaApp.Configuration.AuthorizeAttribute;

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
            */
        }


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
            if (ModelState.IsValid && model.Password == model.ConfirmPassword)
            {
                User user = new User();
                user.first_name = model.first_name;
                user.last_name = model.last_name;
                user.date_created = DateTime.Now;
                user.UserName = model.UserName;
                user.date_updated = model.date_updated;
                user.birth_date = model.birth_date;
                user.active = model.active;
                user.ImageFile = model.ImageFile;
                user.activation_key = model.activation_key;
                user.country = model.country;
                user.city = model.city;
                user.state = model.state;
                user.gender = model.gender;
                user.Email = model.Email;
                using (var memoryStream = new MemoryStream())
                {
                    await user.ImageFile.CopyToAsync(memoryStream);
                    user.ImageData = memoryStream.ToArray();
                }




                /*var userAdded = _context.Users.Add(user);*/

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
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
                    return Ok(newUser);
                }
                /*      this._context.SaveChanges();

                  var currentUser = this._userManager.FindByIdAsync(userAdded.Entity.Id);

                  this._userManager.AddToRoleAsync(currentUser.Result, "Administrator");*/

            }

            return BadRequest("Registration has failed!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        public async Task<ActionResult<IEnumerable<Posts>>> GetPosts()
        {
            return await _context.Posts.Include(post => post.User).ToListAsync();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, User user)
        {
            if (string.IsNullOrEmpty(user.first_name) && user.last_name == "")
            {
                //error
            }

            var userToFind = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);

            userToFind.activation_key = user.activation_key;
            userToFind.active = user.active;
            userToFind.city = user.city;
            userToFind.country = user.country;
            userToFind.date_updated = DateTime.Now;
            userToFind.birth_date = user.birth_date;
            userToFind.Email = user.Email;
            userToFind.first_name = user.first_name;
            userToFind.last_name = user.last_name;
            userToFind.gender = user.gender;
            userToFind.UserName = user.UserName;
            userToFind.state = user.state;
            userToFind.profile_picture_url = user.profile_picture_url;

            if (user.ImageFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await user.ImageFile.CopyToAsync(memoryStream);
                    userToFind.ImageData = memoryStream.ToArray();
                }
            }

            _context.Update(userToFind);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("allusers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        [HttpPost("user")]
        public async Task<User> GetLoggedUser(LoggedUser email)
        {
            var user = await _userManager.FindByEmailAsync(email.email);
            var userToFind = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == user.Email);
            return userToFind;
        }
    

    }
}

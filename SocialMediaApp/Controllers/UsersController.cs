using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Configuration;
using SocialMediaApp.Models;

namespace SocialMediaApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly SocialNetworkDbContext _context;
        private UserManager<User> _userManager { get; set; }
        private SignInManager<User> _signInManager { get; set; }
        private RoleManager<User> _roleManager { get; set; }


        public UsersController(SocialNetworkDbContext context, SignInManager<User> signInManager, UserManager<User> _userManager)
        {
            _context = context;
            _signInManager = signInManager;
            this._userManager = _userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            return Json(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,password,first_name,last_name,role,gender,city,state,country,profile_picture_url,birth_date,date_created,date_updated,active,activation_key")] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                

                var newUser = new User();
                newUser.first_name = user.first_name;
                newUser.last_name = user.last_name;
                newUser.role = user.role;
                newUser.gender = user.gender;
                newUser.city = user.city;
                newUser.state = user.state;
                newUser.country = user.country;
                newUser.profile_picture_url = user.profile_picture_url;
                newUser.birth_date = user.birth_date;
                newUser.date_created = user.date_created;
                newUser.date_updated = user.date_updated;
                newUser.active = user.active;
                newUser.activation_key = user.activation_key;
                _context.Add(newUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            userToFind.role = user.role;
            userToFind.UserName = user.UserName;
            userToFind.state = user.state;
            userToFind.profile_picture_url = user.profile_picture_url;


            
            await _context.SaveChangesAsync();

            return View();
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'SocialNetworkDbContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
          return _context.Users.Any(e => e.Id == id);
        }
    }
}

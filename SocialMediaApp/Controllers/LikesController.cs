using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SocialMediaApp.Configuration;
using SocialMediaApp.Models;
using SocialMediaApp.ViewModels;

namespace SocialMediaApp.Controllers
{
    public class LikesController : Controller
    {
        private readonly SocialNetworkDbContext _context;
        private UserManager<User> _userManager { get; set; }

        public LikesController(SocialNetworkDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Likes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Likes.ToListAsync());
        }

        // GET: Likes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Likes == null)
            {
                return NotFound();
            }

            var likes = await _context.Likes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (likes == null)
            {
                return NotFound();
            }

            return View(likes);
        }

        // GET: Likes/Create
        public IActionResult Create()
        {
            List<User> users = this._context.Users.ToList();
            List<Posts> posts = _context.Posts.ToList();
            LikePostUserViewModel model = new LikePostUserViewModel();
            model.Users = users;
            model.Posts = posts;
            return View(model);
        }

        // POST: Likes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LikePostUserViewModel likes)
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            var student = this._context.Users.Find(userid);
            var postId = await this._context.Posts.FirstOrDefaultAsync(a => a.Id == likes.PostId);
            var newLikes = new Likes();
            if(student != null) { 
                List<Posts> postList = new List<Posts>();
                postList.Add(postId);
                newLikes.Posts = postList;
                newLikes.date_created = likes.date_created;
                newLikes.User = student;

                this._context.Likes.Add(newLikes);

                await this._context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return BadRequest();


            /*            if (ModelState.IsValid)
                        {
                            _context.Add(likes);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                        return View(likes);*/
        }

        // GET: Likes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Likes == null)
            {
                return NotFound();
            }

            var likes = await _context.Likes.FindAsync(id);
            if (likes == null)
            {
                return NotFound();
            }
            return View(likes);
        }

        // POST: Likes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,date_created")] Likes likes)
        {
            if (id != likes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(likes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LikesExists(likes.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(likes);
        }

        // GET: Likes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Likes == null)
            {
                return NotFound();
            }

            var likes = await _context.Likes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (likes == null)
            {
                return NotFound();
            }

            return View(likes);
        }

        // POST: Likes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Likes == null)
            {
                return Problem("Entity set 'SocialNetworkDbContext.Likes'  is null.");
            }
            var likes = await _context.Likes.FindAsync(id);
            if (likes != null)
            {
                _context.Likes.Remove(likes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LikesExists(int id)
        {
          return _context.Likes.Any(e => e.ID == id);
        }
    }
}

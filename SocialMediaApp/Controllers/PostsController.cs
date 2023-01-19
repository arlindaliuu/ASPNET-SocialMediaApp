using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SocialMediaApp.Configuration;
using SocialMediaApp.Models;
using SocialMediaApp.ViewModels;

namespace SocialMediaApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly SocialNetworkDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PostsController(SocialNetworkDbContext context, IWebHostEnvironment hostEnvironment)
        {

            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
              return View(await _context.Posts.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostUserViewModel posts)
        {
          
                var student = this._context.Users.Find(posts.UserId);
                var newPost = new Posts();

                newPost.caption = posts.caption;
                newPost.latitude = posts.latitude;
                newPost.longtitude = posts.longtitude;
                newPost.post_url = posts.post_url;
                newPost.ImageFile = posts.ImageFile;
                newPost.date_created = posts.date_created;
                newPost.date_update = posts.date_update;
            
                this._context.Posts.Add(newPost);
                this._context.SaveChanges();

                //Save image to wwwrot/image
  /*              string wwwRootPath = _hostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(posts.ImageFile.FileName);
                string extension = Path.GetExtension(posts.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("ttmmssfff") + extension;
                string path = Path.Combine(wwwRootPath +"/Image/", filename);
                using(var fileStream = new FileStream(path, FileMode.Create))
                {
                    await posts.ImageFile.CopyToAsync(fileStream);
                }*/
                //Insert record
        /*        _context.Add(newPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            */
            return View();
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts.FindAsync(id);
            if (posts == null)
            {
                return NotFound();
            }
            return View(posts);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,caption,latitude,longtitude,post_url,date_created,date_update")] Posts posts)
        {
            if (id != posts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostsExists(posts.Id))
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
            return View(posts);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'SocialNetworkDbContext.Posts'  is null.");
            }
            var posts = await _context.Posts.FindAsync(id);
            if (posts != null)
            {
                _context.Posts.Remove(posts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostsExists(int id)
        {
          return _context.Posts.Any(e => e.Id == id);
        }
    }
}

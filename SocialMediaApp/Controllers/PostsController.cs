﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> Index(string searchString,string sortOrder,int pg=1)
        {
            ViewBag.PriceSortParam = String.IsNullOrEmpty(sortOrder) ? "longtitude_desc" : "";
            List<Posts> posts = _context.Posts.ToList();

            var Posts = from b in _context.Posts.Include(m => m.Id).Include(m => m.caption)
                        select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                Posts = Posts.Where(b => b.caption.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "price_desc":
                    Posts = Posts.OrderByDescending(b => b.longtitude);
                    break;
                default:
                    Posts = Posts.OrderBy(b => b.longtitude);
                    break;
            }
            const int pageSize = 3;
            if (pg < 1)
                pg = 1;

            int rescCount = posts.Count();

            var pager = new Pager(rescCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;

            var data = posts.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(data);
/*              return View(await _context.Posts.ToListAsync());
*/        }

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
            List<User> users = this._context.Users.ToList();
            PostUserViewModel model = new PostUserViewModel();
            model.Users = users;
            return View(model);
            
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostUserViewModel posts)
        {
            if (posts.ImageFile == null || posts.ImageFile.Length == 0)
            {
                return Content("File not selected");
            }
            var student = this._context.Users.Find(posts.UserId);
                var newPost = new Posts();
           
                newPost.caption = posts.caption;
                newPost.latitude = posts.latitude;
                newPost.longtitude = posts.longtitude;
                newPost.post_url = posts.post_url;
                newPost.ImageFile = posts.ImageFile;
                newPost.date_created = posts.date_created;
                newPost.date_update = posts.date_update;
                newPost.User = student;

            using (var memoryStream = new MemoryStream())
            {
                await posts.ImageFile.CopyToAsync(memoryStream);
                newPost.ImageData = memoryStream.ToArray();
            }

            //Insert record    
            this._context.Posts.Add(newPost);
            await this._context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, Posts posts)
        {
            if (id != posts.Id)
            {
                return NotFound();
            }
            if (posts.ImageFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await posts.ImageFile.CopyToAsync(memoryStream);
                    posts.ImageData = memoryStream.ToArray();
                }
            }
                    _context.Update(posts);
                    await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
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

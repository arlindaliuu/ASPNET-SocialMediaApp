﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Configuration;
using SocialMediaApp.Models;

namespace SocialMediaApp.Controllers
{
    public class LikesController : Controller
    {
        private readonly SocialNetworkDbContext _context;

        public LikesController(SocialNetworkDbContext context)
        {
            _context = context;
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
                .FirstOrDefaultAsync(m => m.id == id);
            if (likes == null)
            {
                return NotFound();
            }

            return View(likes);
        }

        // GET: Likes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Likes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,date_created")] Likes likes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(likes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(likes);
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
        public async Task<IActionResult> Edit(int id, [Bind("id,date_created")] Likes likes)
        {
            if (id != likes.id)
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
                    if (!LikesExists(likes.id))
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
                .FirstOrDefaultAsync(m => m.id == id);
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
          return _context.Likes.Any(e => e.id == id);
        }
    }
}
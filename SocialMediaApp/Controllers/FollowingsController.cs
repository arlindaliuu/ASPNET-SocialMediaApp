using System;
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
    public class FollowingsController : Controller
    {
        private readonly SocialNetworkDbContext _context;

        public FollowingsController(SocialNetworkDbContext context)
        {
            _context = context;
        }

        // GET: Followings
        public async Task<IActionResult> Index()
        {
              return View(await _context.Followings.ToListAsync());
        }

        // GET: Followings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Followings == null)
            {
                return NotFound();
            }

            var followings = await _context.Followings
                .FirstOrDefaultAsync(m => m.followingId == id);
            if (followings == null)
            {
                return NotFound();
            }

            return View(followings);
        }

        // GET: Followings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Followings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("followingId,date_created")] Followings followings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(followings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(followings);
        }

        // GET: Followings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Followings == null)
            {
                return NotFound();
            }

            var followings = await _context.Followings.FindAsync(id);
            if (followings == null)
            {
                return NotFound();
            }
            return View(followings);
        }

        // POST: Followings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("followingId,date_created")] Followings followings)
        {
            if (id != followings.followingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(followings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FollowingsExists(followings.followingId))
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
            return View(followings);
        }

        // GET: Followings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Followings == null)
            {
                return NotFound();
            }

            var followings = await _context.Followings
                .FirstOrDefaultAsync(m => m.followingId == id);
            if (followings == null)
            {
                return NotFound();
            }

            return View(followings);
        }

        // POST: Followings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Followings == null)
            {
                return Problem("Entity set 'SocialNetworkDbContext.Followings'  is null.");
            }
            var followings = await _context.Followings.FindAsync(id);
            if (followings != null)
            {
                _context.Followings.Remove(followings);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FollowingsExists(int id)
        {
          return _context.Followings.Any(e => e.followingId == id);
        }
    }
}

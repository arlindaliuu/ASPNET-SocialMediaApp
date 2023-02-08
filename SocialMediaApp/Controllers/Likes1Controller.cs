using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Configuration;
using SocialMediaApp.Models;
using SocialMediaApp.ViewModels;

namespace SocialMediaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Likes1Controller : ControllerBase
    {
        private readonly SocialNetworkDbContext _context;
        private UserManager<User> _userManager { get; set; }

        public Likes1Controller(SocialNetworkDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Likes1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Likes>>> GetLikes()
        {
            return await _context.Likes.ToListAsync();
        }

        // GET: api/Likes1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Likes>> GetLikes(int id)
        {
            var likes = await _context.Likes.FindAsync(id);

            if (likes == null)
            {
                return NotFound();
            }

            return likes;
        }

        // PUT: api/Likes1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLikes(int id, Likes likes)
        {
            if (id != likes.ID)
            {
                return BadRequest();
            }

            _context.Entry(likes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Likes1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Likes>> PostLikes(LikePostUserViewModel likes)
        {
            var student = this._context.Users.Find(likes.UserId);
            var postId = await this._context.Posts.FirstOrDefaultAsync(a => a.Id == likes.PostId);
            var newLikes = new Likes();
            if (student != null)
            {
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

            /*    _context.Likes.Add(likes);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLikes", new { id = likes.ID }, likes);*/
        }

        // DELETE: api/Likes1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLikes(int id)
        {
            var likes = await _context.Likes.FindAsync(id);
            if (likes == null)
            {
                return NotFound();
            }

            _context.Likes.Remove(likes);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("postslikes")]
        public IEnumerable<dynamic> GetLikesCountPerPost()
        {
            
                var queryResult = from l in _context.Likes
                              from p in l.Posts
                              group p by p.Id into g
                              select new { PostId = g.Key, Count = g.Count() };

            return queryResult.ToList();
        }
        private bool LikesExists(int id)
        {
            return _context.Likes.Any(e => e.ID == id);
        }
    }
}


using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Models;

namespace SocialMediaApp.Configuration
{
    public class SocialNetworkDbContext:DbContext
    {
        public SocialNetworkDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Followings> Followings { get; set; }
        public DbSet<Likes> Likes { get; set; }
    }
}

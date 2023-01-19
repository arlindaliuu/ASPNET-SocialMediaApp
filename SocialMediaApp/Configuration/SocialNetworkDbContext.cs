
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Models;

namespace SocialMediaApp.Configuration
{
    public class SocialNetworkDbContext:IdentityDbContext<User>
    {
        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options) : base(options)
        {

        }
        /*public DbSet<User> Users { get; set; }*/
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Followings> Followings { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Comments> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>()
            //    .HasKey(s => s.Id);
            //modelBuilder.Entity<IdentityUserRole<string>>()
            //    .HasKey(s => s.id);
            //modelBuilder.Entity<IdentityUserToken<string>>()
            //    .HasKey(s => s.UserId);
            /*            modelBuilder.Entity<Posts>().HasKey(x => new { x.duplicateId });
                        modelBuilder.Entity<Likes>().HasKey(x => new { x.duplicateId });
                        modelBuilder.Entity<Comments>().HasKey(x => new { x.duplicateId });
                        modelBuilder.Entity<Followings>().HasKey(x => new { x.duplicateId });
            */

        }
    }
}

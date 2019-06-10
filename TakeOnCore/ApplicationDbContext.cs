using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TakeOnCore.Models;
using TakeOnFront;



namespace TakeOnFront.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }
        

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ApplicationDbContext() { }
         


    }
}

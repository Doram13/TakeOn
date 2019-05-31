using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TakeOnCore.Models;


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


        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=Server=(localdb)\\mssqllocaldb;Database=aspnet-TakeOn.Dev;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

    */
         


    }
}

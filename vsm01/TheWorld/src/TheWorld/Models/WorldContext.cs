using System;
using Microsoft.Data.Entity;
using TheWorld.Models;
using TheWorld;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TheWolrd.Models
{
    public class WorldContext : IdentityDbContext<WorldUser>
    {
        public WorldContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:WorldContextConnection"];

            optionsBuilder.UseSqlServer(connString);


            base.OnConfiguring(optionsBuilder);
        }
    }
}
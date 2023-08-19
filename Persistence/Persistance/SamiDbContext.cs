using Domain.Entities;
using Infrastructure.Identity.Configuration;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class SamiDbContext : IdentityDbContext<User>
    {
        public DbSet<Person> People { get; set; }
        public SamiDbContext(DbContextOptions<SamiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IdentityUserLoginConfiquration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

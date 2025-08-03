using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Models.AuthModels;

namespace School.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        public DbSet <User> Users { get; set; }
        public DbSet <Role> Roles { get; set; }
        public DbSet <UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().
                HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);


            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "User" },
                new Role { Id = 2, Name = "Admin" }
            );

        }

    }
}

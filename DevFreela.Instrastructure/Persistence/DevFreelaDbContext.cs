using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Instrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        { 
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkilss { get; set; }
        public DbSet<ProjectComments> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Freelancer)
                .WithMany(f => f.FreelanceProjects)
                .HasForeignKey(p => p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
               .HasOne(p => p.Client)
               .WithMany(c => c.OwnedProjects)
               .HasForeignKey(p => p.IdClient)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComments>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<ProjectComments>()
              .HasOne(p => p.Project)
              .WithMany(p => p.Comments)
              .HasForeignKey(p => p.IdProject)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComments>()
             .HasOne(p => p.User)
             .WithMany(u => u.Comments)
             .HasForeignKey(p => p.IdUser)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
              .HasMany(u => u.Skills)
              .WithOne()
              .HasForeignKey(p => p.IdSkill)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Skill>()
              .HasKey(p => p.Id);

            modelBuilder.Entity<UserSkill>()
              .HasKey(p => p.Id);
        }
    }
}

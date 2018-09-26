using Microsoft.EntityFrameworkCore;
using IncorrectSyntaxNearTheKeywordAS.Models;
using System;

namespace IncorrectSyntaxNearTheKeywordAS
{
    public class DataContext : DbContext
    {
        #region CTORs
        public DataContext(
            DbContextOptions<DataContext> options) : base(options)
        {
            Database.SetCommandTimeout(new TimeSpan(0, 1, 30));
        }
        #endregion CTORs
        public DbSet<Call> Calls { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Team> Teams { get; set; }
        
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Call>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created).ValueGeneratedOnAdd().HasDefaultValueSql("SYSDATETIMEOFFSET()");
            });

            modelBuilder.Entity<JobTeam>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.TeamId });
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}

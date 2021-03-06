﻿using Microsoft.EntityFrameworkCore;
using IncorrectSyntaxNearTheKeywordAS.Models;
using IncorrectSyntaxNearTheKeywordAS.Models.Maps;
using System;
using System.Linq;

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
        public DbSet<TelemCall> TelemCalls { get; set; }
        public DbSet<TelemCallStack> TelemCallStacks { get; set; }
        public DbSet<TelemJob> TelemJobs { get; set; }
        public DbSet<TelemJobSupplier> TelemJobSuppliers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TelemCall>().Map();
            modelBuilder.Entity<TelemCallStack>().Map();
            modelBuilder.Entity<TelemJob>().Map();
            modelBuilder.Entity<TelemJobSupplier>().Map();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}

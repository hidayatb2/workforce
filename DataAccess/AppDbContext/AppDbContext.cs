﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var dbContextHandler = new DbContextHandler();

            dbContextHandler.SetModelBuilderSettings(modelBuilder);

            dbContextHandler.SeedInitialData(modelBuilder);
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Labour> Labour { get; set; }

        public DbSet<Manager> Manager { get; set; }

        public DbSet<Contractor> Contractor { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }
    }
}

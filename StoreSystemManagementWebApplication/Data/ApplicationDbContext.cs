﻿using Microsoft.EntityFrameworkCore;
using StoreSystemManagementWebApplication.Models.Entities;

namespace StoreSystemManagementWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }

        public DbSet<Product> Products { get; set; }
    }
}

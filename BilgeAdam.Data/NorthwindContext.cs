﻿using BilgeAdam.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdam.Data
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
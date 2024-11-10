﻿using FoodCoupons.core.DL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        // DbSet for User table
        // DbSet for Bus table

        // Optional: You can override OnModelCreating to configure model properties, relationships, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity


            base.OnModelCreating(modelBuilder);




        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }





    }
}

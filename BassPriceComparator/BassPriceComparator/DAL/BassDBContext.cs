﻿using BassPriceComparator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BassPriceComparator.DAL
{
    public class BassDBContext : DbContext
    {
        public BassDBContext() : base("BassDBContext")
        {

        }

        public DbSet<Bass> Basses { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<BasePrice> BasePrices { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Bass>().HasRequired(b => b.brand);

            modelBuilder.Entity<BasePrice>().HasRequired(b => b.bass);
            modelBuilder.Entity<BasePrice>().HasRequired(b => b.source);
        }
    }
}
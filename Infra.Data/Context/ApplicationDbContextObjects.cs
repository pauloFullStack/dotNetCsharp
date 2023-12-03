﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class ApplicationDbContextObjects : DbContext
    {
        public ApplicationDbContextObjects(DbContextOptions<ApplicationDbContextObjects> options) : base(options) { }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* Essem metodo ApplyConfigurationsFromAssembly percorre todo o assembly e pega as classes que implementaram a interface: IEntityTypeConfiguration se não teria que fazer dessa forma:
              builder.ApplyConfiguration(new CategoryConfiguration())    
              builder.ApplyConfiguration(new ProductConfiguration())  
             */
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContextObjects).Assembly);
        }
    }
}

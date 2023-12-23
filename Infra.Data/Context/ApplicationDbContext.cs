using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

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

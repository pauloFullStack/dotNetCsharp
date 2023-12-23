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

            modelBuilder.Entity<Category>()
                 .ToTable("categories") // Nome da tabela no outro banco de dados
                 .HasKey(c => c.UserId);

            modelBuilder.Entity<Category>()
                .Property<string>("UserId");

            modelBuilder.Entity<Category>()
                .HasOne<IdentityUser>() // Relacionamento com ApplicationUser do Identity
                .WithMany()
                .HasForeignKey("UserId")
                .IsRequired();

            modelBuilder.Ignore<Category>();

        }
    }
}

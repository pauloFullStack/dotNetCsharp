using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();

            builder
            .HasOne(c => c.User) // Referenciando a Propriedade de navegação da tabela 'aspnetuser' no dominio 'Category'
            .WithMany() // Uma categoria pode ter muitos usuários (ou um usuário pode ter muitas categorias)
            .HasForeignKey(c => c.UserId) // Chave estrangeira para UserId na tabela Categories
            .IsRequired();

            /* o HasData faz igual o seeder ele popula a tabela, nesse caso no momento da criação da tabela */
            //builder.HasData(
            //    new Category(1, "Material Escolar"),
            //    new Category(2, "Eletrônicos"),
            //    new Category(3, "Acessórios"));
        }
    }
}

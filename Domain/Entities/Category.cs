using Domain.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Category : Entity
    {
        public string? Name { get; private set; }


        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Valor Inválido");
            ValidateDomain(name);
            Id = id;
        }

        // Traz produtos relacionados a categoria 
        //public ICollection<Product> Products { get; set; }


        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. Nome é obrigatório");
            DomainExceptionValidation.When(name.Length < 3, "Nome inválido, no minimo 3 caracteres");
            Name = name;
        }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletionDate { get; set; }

        public string? UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}

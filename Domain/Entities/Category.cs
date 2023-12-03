using Domain.Validation;
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

        public ICollection<Product> Products { get; set; }


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
    }
}

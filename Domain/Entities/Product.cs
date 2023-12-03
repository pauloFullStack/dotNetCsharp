using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Valor Inválido");
            ValidateDomain(name, description, price, stock, image);
            Id = id;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            /* Validate Name */
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. Nome é obrigatório");
            DomainExceptionValidation.When(name.Length < 3, "Nome inválido, no minimo 3 caracteres");

            /* Validate Name */
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição inválido. Descrição é obrigatório");
            DomainExceptionValidation.When(description.Length < 5, "Descrição inválido, no minimo 5 caracteres");

            /* Validate Price */
            DomainExceptionValidation.When(price < 0, "Valor do preço é inválido");

            /* Validate Stock */
            DomainExceptionValidation.When(stock < 0, "Valor do estoque é inválido");

            /* Validate Image */
            //DomainExceptionValidation.When(!string.IsNullOrEmpty(image) && image.Length > 250, "Nome da Imagem muito longa maximo 250 caracteres");
            DomainExceptionValidation.When(image?.Length > 250, "Nome da Imagem muito longa maximo 250 caracteres");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;


        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

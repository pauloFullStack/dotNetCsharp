using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatório!")]
        [MinLength(5, ErrorMessage = "A descrição deve ter pelo menos 5 caracteres")]
        [MaxLength(100, ErrorMessage = "O descrição não pode ter mais de 200 caracteres")]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório!")]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "O estoque é obrigatório")]
        [Range(1, 9999)]
        [DisplayName("Estoque")]
        public int Stock { get; set; }


        [MaxLength(250, ErrorMessage = "O nome da imagem deve ter até 250 caracteres")]
        [DisplayName("Nome Imagem")]
        public string Image { get; set; }

        public Category Category { get; set; }

        [DisplayName("Categorias")]
        public int CategoryId { get; set; }
    }
}

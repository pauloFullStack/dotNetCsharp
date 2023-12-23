using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!!!")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; }
        public string? UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PaginationDTO
    {
        public int Pagina { get; set; }
        public int QuantidadePorPagina { get; set; }
        public string? nomeFiltro { get; set; }
    }
}

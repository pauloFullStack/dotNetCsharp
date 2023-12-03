using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pagination
    {
        public int Pagina { get; set; } = 1;
        public int QuantidadePorPagina { get; set; } = 5;
        public string? nomeFiltro { get; set; }
    }
}

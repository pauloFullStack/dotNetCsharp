using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserTokenDTO
    {
        public bool Authenticated { get; set; }
        public DateTime Expiration { get; set; }
        public string? Token { get; set; }
        public string? Message { get; set; }
    }
}

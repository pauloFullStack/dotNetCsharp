using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AspNetRolesDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }

    public class GetDataPermissionsDTO
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
        public string? RoleId { get; set; }
    }
}

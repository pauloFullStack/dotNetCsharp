using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AspNetRoles
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }

    public class GetDataPermissions
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
        public string? RoleId { get; set; }
    }
}

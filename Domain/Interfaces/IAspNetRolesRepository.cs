using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAspNetRolesRepository
    {
        Task<IEnumerable<IdentityRole>> GetRolesAsync();
        Task<IEnumerable<GetDataPermissions>> GetUserPermissions(string userId);
        Task<IEnumerable<IdentityRole>> GetPaginationAndSearch(Pagination pagination, HttpContext context);
        Task<IdentityRole> GetByIdAsync(int? id);
        Task<ActionResult<AspNetRoles>> CreateAsync(AspNetRoles identityRole);
        Task<IdentityRole> UpdateAsync(IdentityRole identityRole);
        Task<IdentityRole> RemoveAsync(IdentityRole identityRole);
        Task<bool> DeleteUserPermissionAsync(string userId, string roleId);
    }
}

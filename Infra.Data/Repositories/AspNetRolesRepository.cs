using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class AspNetRolesRepository : IAspNetRolesRepository
    {
        IDbContextFactory<ApplicationDbContext> _rolesContext;
        public AspNetRolesRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _rolesContext = context;
        }



        private async Task<ApplicationDbContext> CreateDbContextAsync()
        {
            return await _rolesContext.CreateDbContextAsync();
        }

        public async Task<ActionResult<AspNetRoles>> CreateAsync(AspNetRoles identityRole)
        {
            try
            {
                using var context = await CreateDbContextAsync();
                IdentityRole objectRoles = new IdentityRole();

                objectRoles.Name = identityRole.Name;
                objectRoles.NormalizedName = identityRole.Name.ToUpper();

                context.Add(objectRoles);
                await context.SaveChangesAsync();
                return identityRole;
            }
            catch (Exception ex)
            {

                throw;
            }
        }




        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            using var context = await CreateDbContextAsync();
            return await context.Roles.ToListAsync();
        }

        public async Task<IEnumerable<IdentityRole>> GetPaginationAndSearch(Pagination pagination, HttpContext context)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityRole> GetByIdAsync(int? id)
        {
            using var context = await CreateDbContextAsync();
            return await context.Roles.FindAsync(id);
        }

        //public async Task<IEnumerable<IdentityUserRole<string>>> GetUserPermissions(string userId)
        public async Task<IEnumerable<GetDataPermissions>> GetUserPermissions(string userId)
        {
            using var context = await CreateDbContextAsync();
            return await context.Users
            .Where(u => u.Id == userId)
            .Join(
                context.UserRoles,
                user => user.Id,
                userRole => userRole.UserId,
                (user, userRole) => new { user, userRole }
            )
            .Join(
                context.Roles,
                ur => ur.userRole.RoleId,
                role => role.Id,
                (ur, role) => new { ur.user, role }
            )
            .Select(result => new GetDataPermissions()
            {
                UserId = result.user.Id,
                UserName = result.user.UserName,
                RoleName = result.role.Name,
                RoleId = result.role.Id
                // Adicione outras propriedades que deseja recuperar
            })
        .ToListAsync();

            //using var context = await CreateDbContextAsync();
            //return await context.UserRoles.Where(field => field.UserId == userId).ToListAsync();
        }





        public async Task<IdentityRole> UpdateAsync(IdentityRole identityRole)
        {
            throw new NotImplementedException();
        }





        public async Task<IdentityRole> RemoveAsync(IdentityRole identityRole)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserPermissionAsync(string userId, string roleId)
        {
            using var context = await CreateDbContextAsync();
            var userRoleDelte = await context.UserRoles.FirstOrDefaultAsync(field => field.RoleId == roleId && field.UserId == userId);

            if (userRoleDelte is null)
                return false;

            context.UserRoles.Remove(userRoleDelte);
            await context.SaveChangesAsync();

            return true;
        }
    }
}

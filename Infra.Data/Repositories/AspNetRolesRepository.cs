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

        public async Task<IdentityRole> UpdateAsync(IdentityRole identityRole)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityRole> RemoveAsync(IdentityRole identityRole)
        {
            throw new NotImplementedException();
        }
    }
}

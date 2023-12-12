using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            using var context = await CreateDbContextAsync();
            return await context.Roles.ToListAsync();
        }
    }
}

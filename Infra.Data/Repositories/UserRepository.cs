using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Infra.Data.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        IDbContextFactory<ApplicationDbContext> _userContext;
        private readonly UserManager<IdentityUser> _userManager;
        public UserRepository(IDbContextFactory<ApplicationDbContext> context, UserManager<IdentityUser> userManager)
        {
            _userContext = context;
            _userManager = userManager; 
        }
        private async Task<ApplicationDbContext> CreateDbContextAsync()
        {
            return await _userContext.CreateDbContextAsync();
        }

        public async Task<IEnumerable<IdentityUser>> GetUsersAsync()
        {
            using var context = await CreateDbContextAsync();
            return await context.Users.ToListAsync();
        }

        public async Task<IdentityUser> GetUserAsync(string id)
        {
            using var context = await CreateDbContextAsync();
            return await context.Users.FindAsync(id);
        }

        public async Task<IdentityUser> GetUserNameAsync(string userName)
        {
            using var context = await CreateDbContextAsync();
            return await context.Users.FirstOrDefaultAsync(field => field.UserName == userName);
        }

        public async Task<ActionResult<IdentityUser>> CreateAsync(string email, string password)
        {
            try
            {
                using var context = await CreateDbContextAsync();

                var newUser = new IdentityUser { UserName = email, Email = email };
                var result = await _userManager.CreateAsync(newUser, password);
                return newUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteUserAsync(string id)
        {

            using var context = await CreateDbContextAsync();
            var identityUser = await context.Users.FindAsync(id);

            if (identityUser is null)
                return false;

            context.Users.Remove(identityUser);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateUserRoleAsync(string id, User user)
        {
            IdentityUserRole<string> aspNetUserRoles = new IdentityUserRole<string>();
            aspNetUserRoles.UserId = id;
            aspNetUserRoles.RoleId = user.RoleId;

            using var context = await CreateDbContextAsync();
            context.UserRoles.Add(aspNetUserRoles);
            await context.SaveChangesAsync();
            return true;

        }
        
    }
}

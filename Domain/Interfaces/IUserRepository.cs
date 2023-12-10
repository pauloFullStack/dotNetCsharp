using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetUsersAsync();
        Task<IdentityUser> GetUserAsync(string id);
        Task<bool> DeleteUserAsync(string id);
        Task<bool> UpdateUserRoleAsync(string id, User user);
    }
}

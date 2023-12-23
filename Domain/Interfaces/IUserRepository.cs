using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetUsersAsync();
        Task<IdentityUser> GetUserAsync(string id);
        Task<IdentityUser> GetUserNameAsync(string userName);
        Task<ActionResult<IdentityUser>> CreateAsync(string email, string password);
        Task<bool> DeleteUserAsync(string id);
        Task<bool> UpdateUserRoleAsync(string id, User user);
    }
}

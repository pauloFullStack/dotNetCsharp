using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserAsync(string id);
        Task<UserDTO> GetUserNameAsync(string userName);
        Task<NotificationsDTO> AddAsync(UserDTO userDTO);
        Task<bool> UpdateUserRoleAsync(string id, UserDTO user);
        Task<bool> DeleteUserAsync(string id);
    }
}

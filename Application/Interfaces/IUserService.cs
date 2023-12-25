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
        Task<IEnumerable<GetDataPermissionsDTO>> GetUserPermissionsAsync(string userId);
        Task<UserDTO> GetUserNameAsync(string userName);
        Task<NotificationsDTO> AddAsync(UserDTO userDTO);
        Task<bool> UpdateUserRoleAsync(UserDTO user, List<string> ids);
        Task<bool> DeleteUserAsync(string id);
        Task<bool> DeleteUserPermissionAsync(string userId, string roleId);
    }
}

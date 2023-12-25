using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IAspNetRolesService
    {
        Task<List<AspNetRolesDTO>> GetRolesAsync();
        Task<IEnumerable<AspNetRolesDTO>> GetPaginationAndSearch(PaginationDTO paginationDTO, HttpContext context);
        Task<IEnumerable<GetDataPermissionsDTO>> GetUserPermissions(string userId);
        Task<AspNetRolesDTO> GetByIdAsync(int? id);
        Task<NotificationsDTO> AddAsync(AspNetRolesDTO aspNetRolesDTO);
        Task UpdateAsync(AspNetRolesDTO aspNetRolesDTO);
        Task RemoveAsync(int? id);
        Task<bool> DeleteUserPermissionAsync(string userId, string roleId);
    }
}

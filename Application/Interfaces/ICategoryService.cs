using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<IEnumerable<CategoryDTO>> GetPaginationAndSearch(PaginationDTO paginationDTO, HttpContext context);
        Task<CategoryDTO> GetByIdAsync(int? id);
        Task<NotificationsDTO> AddAsync(CategoryDTO categoryDTO, string userName);
        Task<NotificationsDTO> UpdateAsync(CategoryDTO categoryDTO);
        Task RemoveAsync(int? id);
    }
}

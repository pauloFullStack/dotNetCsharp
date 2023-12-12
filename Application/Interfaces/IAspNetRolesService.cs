using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IAspNetRolesService
    {
        Task<IEnumerable<AspNetRolesDTO>> GetRoles();
    }
}

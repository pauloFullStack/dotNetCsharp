using AutoMapper;
using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Pagination, PaginationDTO>().ReverseMap();

            CreateMap<IdentityUser, UserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<IdentityRole, AspNetRolesDTO>().ReverseMap();
            CreateMap<AspNetRoles, AspNetRolesDTO>().ReverseMap();
            CreateMap<GetDataPermissions, GetDataPermissionsDTO>().ReverseMap();
            CreateMap<IdentityUserRole<string>, AspNetUserRolesDTO>().ReverseMap();

        }
    }
}

using AutoMapper;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AspNetRolesService : IAspNetRolesService
    {
        private IAspNetRolesRepository _aspNetRolesRepository;
        private readonly IMapper _mapper;
        public AspNetRolesService(IAspNetRolesRepository aspNetRolesRepository, IMapper mapper)
        {
            _aspNetRolesRepository = aspNetRolesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AspNetRolesDTO>> GetUsersAsync()
        {
            var aspNetRolesEntity = await _aspNetRolesRepository.GetRoles();
            return _mapper.Map<IEnumerable<AspNetRolesDTO>>(aspNetRolesEntity);

        }

        public async Task<IEnumerable<AspNetRolesDTO>> GetRoles()
        {
            var userEntity = await _aspNetRolesRepository.GetRoles();
            return _mapper.Map<IEnumerable<AspNetRolesDTO>>(userEntity);
        }
    }
}

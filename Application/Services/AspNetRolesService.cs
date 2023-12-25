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

        //public async Task<IEnumerable<AspNetRolesDTO>> GetUsersAsync()
        //{
        //    var aspNetRolesEntity = await _aspNetRolesRepository.GetRolesAsync();
        //    return _mapper.Map<IEnumerable<AspNetRolesDTO>>(aspNetRolesEntity);

        //}

        public async Task<NotificationsDTO> AddAsync(AspNetRolesDTO aspNetRolesDTO)
        {

            try
            {
                var aspNetRolesEntity = _mapper.Map<AspNetRoles>(aspNetRolesDTO);
                var response = await _aspNetRolesRepository.CreateAsync(aspNetRolesEntity);
                return new NotificationsDTO("Permissão cadastrado com sucesso", "success");
            }
            catch (Exception ex)
            {
                return new NotificationsDTO("Erro de conexão!", "error");
            }



        }

        public async Task<List<AspNetRolesDTO>> GetRolesAsync()
        {
            var userEntity = await _aspNetRolesRepository.GetRolesAsync();
            return _mapper.Map<List<AspNetRolesDTO>>(userEntity);
        }

        public async Task<IEnumerable<AspNetRolesDTO>> GetPaginationAndSearch(PaginationDTO paginationDTO, HttpContext context)
        {
            throw new NotImplementedException();
        }

        public async Task<AspNetRolesDTO> GetByIdAsync(int? id)
        {
            var categoryEntity = await _aspNetRolesRepository.GetByIdAsync(id);
            return _mapper.Map<AspNetRolesDTO>(categoryEntity);
        }

        public async Task<IEnumerable<GetDataPermissionsDTO>> GetUserPermissions(string userId)
        {
            var listPermissionsUser = await _aspNetRolesRepository.GetUserPermissions(userId);
            return _mapper.Map<IEnumerable<GetDataPermissionsDTO>>(listPermissionsUser);
        }


        public async Task UpdateAsync(AspNetRolesDTO aspNetRolesDTO)
        {
            throw new NotImplementedException();
        }




        public async Task RemoveAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserPermissionAsync(string userId, string roleId)
        {
            return await _aspNetRolesRepository.DeleteUserPermissionAsync(userId, roleId);
        }
    }
}

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
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IAspNetRolesService _aspNetRolesService;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper, IAspNetRolesService aspNetRolesService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _aspNetRolesService = aspNetRolesService;
        }

        public async Task<NotificationsDTO> AddAsync(UserDTO userDTO)
        {


            try
            {
                var result = await _userRepository.CreateAsync(userDTO.Email, userDTO.Password);

                if (result != null && result.Value.Id != null)
                {
                    return new NotificationsDTO("Usuário cadastrado com sucesso", "success");
                }
                else
                {
                    return new NotificationsDTO("Erro de conexão", "error");
                }
            }
            catch (Exception ex)
            {
                return new NotificationsDTO("Entre em contato com suporte!", "error");
            }
        }






        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var userEntity = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(userEntity);
        }

        public async Task<IEnumerable<GetDataPermissionsDTO>> GetUserPermissionsAsync(string userId)
        {
            return _mapper.Map<IEnumerable<GetDataPermissionsDTO>>(await _aspNetRolesService.GetUserPermissions(userId));
        }

        public async Task<UserDTO> GetUserAsync(string id)
        {
            var userEntity = await _userRepository.GetUserAsync(id);
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task<UserDTO> GetUserNameAsync(string userName)
        {
            var userEntity = await _userRepository.GetUserNameAsync(userName);
            return _mapper.Map<UserDTO>(userEntity);
        }




        public async Task<bool> UpdateUserRoleAsync(UserDTO user, List<string> ids)
        {
            try
            {
                foreach (string id in ids)
                {
                    user.RoleId = id;
                    var userEntity = await _userRepository.UpdateUserRoleAsync(user.Id.ToString(), _mapper.Map<User>(user));
                }

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }




        public async Task<bool> DeleteUserAsync(string id)
        {
            var userEntity = await _userRepository.DeleteUserAsync(id);
            return true;
        }

        public async Task<bool> DeleteUserPermissionAsync(string userId, string roleId)
        {
            return await _aspNetRolesService.DeleteUserPermissionAsync(userId, roleId);
        }


    }
}

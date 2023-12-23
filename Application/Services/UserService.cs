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
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult<UserDTO>> AddAsync(UserDTO userDTO)
        {            
            return _mapper.Map<UserDTO>(await _userRepository.CreateAsync(userDTO.Email, userDTO.Password));
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var userEntity = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(userEntity);
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

        public async Task<bool> UpdateUserRoleAsync(string id, UserDTO user)
        {
            var userEntity = await _userRepository.UpdateUserRoleAsync(id, _mapper.Map<User>(user));
            return true;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var userEntity = await _userRepository.DeleteUserAsync(id);
            return true;
        }

    }
}

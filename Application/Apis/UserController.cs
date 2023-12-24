using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Application.Apis
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly IUserService _userService;
        //private readonly IMapper _mapper;
        //public UserController(IUserService userService, IMapper mapper)
        //{
        //    _userService = userService;
        //    _mapper = mapper;
        //}

        //[HttpGet("all")]
        //public async Task<IEnumerable<UserDTO>> Get()
        //{
        //    try
        //    {
        //        return await _userService.GetUsersAsync();
        //    }
        //    catch
        //    {
        //        throw new CategoryExceptions("Erro: contate o suporte");
        //    }
        //}

        //[HttpGet("{id}", Name = "GetUserAsync")]
        //public async Task<UserDTO> Get(string id)
        //{
        //    try
        //    {
        //        return await _userService.GetUserAsync(id);
        //    }
        //    catch
        //    {
        //        throw new CategoryExceptions("Erro: contate o suporte");
        //    }
        //}

        //// Ver porque não esta criando o usuario , a api não esta chegando aqui
        //[HttpPost]
        //public async Task<ActionResult<UserDTO>> Post(UserDTO userDTO)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState); // Retorna os erros de validação
        //    }

        //    try
        //    {
        //        //var user = await _userService.GetUserNameAsync(User.Identity.Name);
        //        //categoriaDTO.UserId = user.Id.ToString();

        //        await _userService.AddAsync(userDTO);
        //        return new CreatedAtRouteResult("GetUserAsync", new { id = userDTO.Id }, userDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CategoryExceptions("Erro: contate o suporte");
        //    }

        //}

        //[HttpPut]
        //public async Task<bool> Put(UserDTO userDTO)
        //{

        //    try
        //    {
        //        await _userService.UpdateUserRoleAsync(userDTO.Id.ToString(), userDTO);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CategoryExceptions("Erro: contate o suporte");
        //    }

        //}

        //[HttpDelete("{id}")]
        //public async Task<bool> Delete(string id)
        //{

        //    try
        //    {
        //        await _userService.DeleteUserAsync(id);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CategoryExceptions("Erro: contate o suporte");
        //    }

        //}

    }
}

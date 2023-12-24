using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Apis
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetRolesController : ControllerBase
    {
        //private readonly IAspNetRolesService _aspNetRolesService;
        //private readonly IMapper _mapper;

        //public AspNetRolesController(IAspNetRolesService aspNetRolesService, IMapper mapper)
        //{
        //    _aspNetRolesService = aspNetRolesService;
        //    _mapper = mapper;
        //}

        //[HttpGet("all")]
        //public async Task<IEnumerable<AspNetRolesDTO>> Get()
        //{
        //    try
        //    {
        //        return await _aspNetRolesService.GetRolesAsync();
        //    }
        //    catch
        //    {
        //        throw new CategoryExceptions("Erro: contate o suporte");
        //    }
        //}

        //[HttpGet("{id}", Name = "GetByIdRolesAsync")]
        //public async Task<AspNetRolesDTO> Get(int id)
        //{
        //    try
        //    {
        //        return await _aspNetRolesService.GetByIdAsync(id);
        //    }
        //    catch
        //    {
        //        throw new CategoryExceptions("Erro: contate o suporte");
        //    }
        //}

        //[HttpPost]
        //public async Task<ActionResult<AspNetRolesDTO>> Post(AspNetRolesDTO aspNetRolesDTO)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState); // Retorna os erros de validação
        //    }

        //    try
        //    {
        //        //var user = await _userService.GetUserNameAsync(User.Identity.Name);
        //        //categoriaDTO.UserId = user.Id.ToString();

        //        await _aspNetRolesService.AddAsync(aspNetRolesDTO);
        //        return new CreatedAtRouteResult("GetByIdRolesAsync", new { id = aspNetRolesDTO.Id }, aspNetRolesDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CategoryExceptions("Erro: contate o suporte");
        //    }

        //}


    }
}

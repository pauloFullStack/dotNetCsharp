using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controller
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetRolesController : ControllerBase
    {
        private readonly IAspNetRolesService _aspNetRolesService;
        private readonly IMapper _mapper;
        
        public AspNetRolesController(IAspNetRolesService aspNetRolesService, IMapper mapper)
        {
            _aspNetRolesService = aspNetRolesService;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<AspNetRolesDTO>> Get()
        {
            try
            {
                return await _aspNetRolesService.GetRoles();
            }
            catch
            {
                throw new CategoryExceptions("Erro: contate o suporte");
            }
        }

    }
}

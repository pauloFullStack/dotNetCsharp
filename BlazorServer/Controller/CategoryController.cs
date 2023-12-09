using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;


namespace BlazorServer.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            try
            {
                return await _categoryService.GetCategoriesAsync();
            }
            catch
            {
                throw new CategoryExceptions("Erro: contate o suporte");
            }
        }


        [HttpGet("{id}", Name = "GetByIdAsync")]
        public async Task<CategoryDTO> Get(int id)
        {
            try
            {
                return await _categoryService.GetByIdAsync(id);
            }
            catch
            {
                throw new CategoryExceptions("Erro: contate o suporte");
            }
        }


        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            try
            {
                return await _categoryService.GetPaginationAndSearch(paginationDTO, HttpContext);
            }
            catch
            {
                throw new CategoryExceptions("Erro: contate o suporte");
            }
        }


        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post(CategoryDTO categoriaDTO)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Retorna os erros de validação
                }

                /* Ver como retorna annotations o erros que estão nos modelos, para mostrar na view */
                await _categoryService.AddAsync(categoriaDTO);
                return new CreatedAtRouteResult("GetByIdAsync", new { id = categoriaDTO.Id }, categoriaDTO);
            }
            catch (Exception ex)
            {
                throw new CategoryExceptions("Erro: contate o suporte");
            }

        }


        [HttpPut]
        public async Task<object> Put(CategoryDTO categoriaDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Retorna os erros de validação
                }

                await _categoryService.UpdateAsync(categoriaDTO);
                return new { message = "Categoria atualizada com sucesso!" };
            }
            catch (Exception ex)
            {
                throw new CategoryExceptions("Erro: contate o suporte");
            }

        }


        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {

            try
            {
                await _categoryService.RemoveAsync(id);
                return new { message = "Categoria deletada com sucesso!" };
            }
            catch (Exception)
            {
                throw new CategoryExceptions("Erro: contate o suporte");
            }

        }
    }
}

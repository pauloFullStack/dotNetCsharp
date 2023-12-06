using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Services
{
    public class CategoryService : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            return await _categoryService.GetCategoriesAsync();
        }

        public async Task<CategoryDTO> PickOnlyOneCategoryAsync(int id)
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


        //public async Task<IEnumerable<CategoryDTO>> Get([FromQuery] PaginationDTO paginationDTO)
        //{
        //    try
        //    {
        //        return await _categoryService.GetPaginationAndSearch(paginationDTO, HttpContext);
        //    }
        //    catch
        //    {
        //        throw new CategoryExceptions("Erro: contate o suporte");
        //    }
        //}


        public async Task<ActionResult<CategoryDTO>> CreateCategoryAsync(CategoryDTO categoriaDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna os erros de validação
            }

            try
            {
                /* Ver como retorna annotations o erros que estão nos modelos, para mostrar na view */
                await _categoryService.AddAsync(categoriaDTO);
                return new CreatedAtRouteResult("GetByIdAsync", new { id = categoriaDTO.Id }, categoriaDTO);
            }
            catch (Exception)
            {
                throw new CategoryExceptions("Erro: contate o suporte");
            }

        }


        public async Task<object> UpdateCategoryAsync(CategoryDTO categoriaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna os erros de validação
            }

            try
            {
                await _categoryService.UpdateAsync(categoriaDTO);
                return new { message = "Categoria atualizada com sucesso!" };
            }
            catch (Exception)
            {
                throw new CategoryExceptions("Erro: contate o suporte");
            }

        }


        public async Task<object> DeleteCategoryAsync(int id)
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

using AutoMapper;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IUserService _userService;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUserService userService)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<NotificationsDTO> AddAsync(CategoryDTO categoryDTO, string userName)
        {
            try
            {
                var user = await _userService.GetUserNameAsync(userName);
                categoryDTO.UserId = user.Id.ToString();

                var categoryEntity = _mapper.Map<Category>(categoryDTO);
                await _categoryRepository.CreateAsync(categoryEntity);
                return new NotificationsDTO("Categoria cadastrada com sucesso", "success");
            }
            catch (Exception ex)
            {
                return new NotificationsDTO("Erro de conexão!", "error");
            }
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetPaginationAndSearch(PaginationDTO paginationDTO, HttpContext context)
        {
            var paginationEntity = _mapper.Map<Pagination>(paginationDTO);
            var categoriesEntity = await _categoryRepository.GetPaginationAndSearch(paginationEntity, context);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task RemoveAsync(int? id)
        {

            try
            {
                var categoryEntity = await _categoryRepository.GetByIdAsync(id);
                await _categoryRepository.RemoveAsync(categoryEntity);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<NotificationsDTO> UpdateAsync(CategoryDTO categoryDTO)
        {
            try
            {
                var categoryEntity = _mapper.Map<Category>(categoryDTO);
                await _categoryRepository.UpdateAsync(categoryEntity);
                return new NotificationsDTO("Voltar para lista de categorias?", "success", $"Categoria {categoryDTO.Name} editado com sucesso!");
            }
            catch (Exception ex)
            {
                return new NotificationsDTO("Erro de conexão!", "error");
            }
        }
    }
}

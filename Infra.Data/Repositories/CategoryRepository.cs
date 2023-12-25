using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Infra.Data.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        IDbContextFactory<ApplicationDbContext> _categoryContext;
        public CategoryRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _categoryContext = context;
        }

        private async Task<ApplicationDbContext> CreateDbContextAsync()
        {
            return await _categoryContext.CreateDbContextAsync();
        }

        public async Task<ActionResult<Category>> CreateAsync(Category category)
        {
            using var context = await CreateDbContextAsync();

            context.Add(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            try
            {
                using var context = await CreateDbContextAsync();
                return await context.Categories.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            try
            {
                using var context = await CreateDbContextAsync();
                return await context.Categories.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetPaginationAndSearch(Pagination pagination, HttpContext context)
        {
            try
            {
                using var contextDb = await CreateDbContextAsync();
                var queryable = contextDb.Categories.AsQueryable();

                if (!string.IsNullOrEmpty(pagination.nomeFiltro))
                    queryable = queryable.Where(x => x.Name.Contains(pagination.nomeFiltro));

                await context.InserirParametroEmPageResponse(queryable, pagination.QuantidadePorPagina);
                return await queryable.Page(pagination).ToListAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<Category> RemoveAsync(Category category)
        {
            using var contextDb = await CreateDbContextAsync();
            contextDb.Remove(category);
            await contextDb.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            using var contextDb = await CreateDbContextAsync();
            contextDb.Update(category);
            await contextDb.SaveChangesAsync();
            return category;
        }
    }
}

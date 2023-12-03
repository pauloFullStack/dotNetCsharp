using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        IDbContextFactory<ApplicationDbContextObjects> _productContext;
        public ProductRepository(IDbContextFactory<ApplicationDbContextObjects> context)
        {
            _productContext = context;
        }


        private async Task<ApplicationDbContextObjects> CreateDbContextAsync()
        {
            return await _productContext.CreateDbContextAsync();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            using var context = await CreateDbContextAsync();
            context.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            using var context = await CreateDbContextAsync();
            return await context.Products
                                        .Include(a => a.Category)
                                        .SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                using var context = await CreateDbContextAsync();
                var result = await context.Products.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            using var context = await CreateDbContextAsync();
            context.Remove(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            using var context = await CreateDbContextAsync();
            context.Update(product);
            await context.SaveChangesAsync();
            return product;
        }
    }
}

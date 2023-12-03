using Domain.Entities;

namespace Infra.Data.Utils
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, Pagination pagination)
        {

            try
            {
                return queryable
                    .Skip((pagination.Pagina - 1) * pagination.QuantidadePorPagina)
                    .Take(pagination.QuantidadePorPagina);
            }
            catch (Exception ex)
            {

                return null;
            }

        }
    }
}

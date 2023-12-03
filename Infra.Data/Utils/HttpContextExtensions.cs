using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Utils
{
    public static class HttpContextExtensions
    {
        public async static Task InserirParametroEmPageResponse<T>(this HttpContext context, IQueryable<T> queryable, int quantidadeTotalRegistroAExbir)
        {
            try
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));


                double quantidadeRegistroTotal = await queryable.CountAsync();
                double totalPaginas = Math.Ceiling(quantidadeRegistroTotal / quantidadeTotalRegistroAExbir);

                /* Salvando as informações no header do response */
                context.Response.Headers.Add("totalPaginas", totalPaginas.ToString());
                context.Response.Headers.Add("quantidadeRegistroTotal", quantidadeRegistroTotal.ToString());
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}

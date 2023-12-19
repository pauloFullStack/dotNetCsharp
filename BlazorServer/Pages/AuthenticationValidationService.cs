using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace BlazorServer.Pages
{
    public interface IAuthenticationValidationService
    {
        Task<AuthenticateResult> ValidateAuthenticationAsync();
    }
    public class AuthenticationValidationService : IAuthenticationValidationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationValidationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AuthenticateResult> ValidateAuthenticationAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            return await httpContext.AuthenticateAsync(IdentityConstants.ApplicationScheme);
        }
    }
}

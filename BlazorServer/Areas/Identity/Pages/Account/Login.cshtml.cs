using BlazorServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorServer.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public LoginModel(SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _configuration = configuration; 
        }

        [BindProperty]
        public InputModel? Input { get; set; }

        public string? ReturnUrl { get; set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {                    
                    var authentication = GenerateToken(Input); // Gere o token JWT para o usuário autenticado
                    string token = authentication.Token;

                    // Armazene o token JWT em um cookie
                    //Response.Cookies.Append("accessToken", token, new CookieOptions
                    //{
                    //    HttpOnly = true,
                    //    Secure = true, // Defina como true se estiver usando HTTPS
                    //    SameSite = SameSiteMode.None // Ajuste o SameSite conforme necessário
                    //});

                    Response.Cookies.Append("accessToken", token);

                    return LocalRedirect(ReturnUrl); // Retorne o token JWT como parte da resposta
                }
                //if (result.Succeeded) return LocalRedirect(ReturnUrl);
            }

            return Page();

        }

        private UserToken GenerateToken(InputModel userInformation)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInformation.Email),
                new Claim("mulher", "geissana"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };


            // gera uma chave com base em algoritmo simetrico, e pega a chave secreta no arquivo appsttings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            // gera a assinatura digital do token usando o algoritmo Hmac e a chave privada
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            // Tempo de expiração do token.
            var takesTokenExpirationValue = _configuration["TokenConfiguration:ExpireHours"];
            var createsTokenExpiration = DateTime.UtcNow.AddHours(double.Parse(takesTokenExpirationValue));


            // classe que representa um token JWT e gera o token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: createsTokenExpiration,
                signingCredentials: credentials
                );

            // retorna os dados com o token e informacoes
            return new UserToken()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = createsTokenExpiration,
                Message = "Token JWT OK"
            };

        }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string? Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }
        }

    }
}

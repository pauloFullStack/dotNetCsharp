using Application.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;
using Microsoft.JSInterop;

// ---- arrumar todo o codigo, começando por essa controller ver se eu uso algo nela , se não usar excluir ,
// ---- arrumor onde registra os serviços e as injeções de dependencia colocar tudo do projeto de injeção de dependencia ,
// ---- colocar os codigos em Application/Service... e organizar o codigo e a estrutura,
// ---- Criar o layout
// acabar de fazer o crud de usuario, e depois o crud de permissões... ai dar mas uma geral e salvar esse projeto como meuFrameworkPadrao para criação de sistemas.. depois fazer um framework padrão para sites...ai começar fazer o sistema pra mim, e pesquisar como ganhar dinheiro na internet usando meus conheciemntos... criar uma segunda renda...
namespace BlazorServer.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IJSRuntime _js;

        public LoginModel(SignInManager<IdentityUser> signInManager, IConfiguration configuration, IJSRuntime js)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _js = js;
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
            ReturnUrl = Url.Content("~/categories");

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

       

        private UserTokenDTO GenerateToken(InputModel userInformation)
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
            return new UserTokenDTO()
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

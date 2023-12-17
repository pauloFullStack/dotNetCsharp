using Application.DTOs;
using BlazorServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Humanizer.In;

namespace BlazorServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesLoginUserController : ControllerBase
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public ResourcesLoginUserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        [HttpGet]
        public ActionResult<string> Get()
        {
            return $"AutorizaController :: Acessado em : {DateTime.Now.ToLongDateString()}";
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _signInManager.SignInAsync(user, false);
            return Ok(GenerateToken(model));

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserModel userInformation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var result = await _signInManager.PasswordSignInAsync(userInformation.Email, userInformation.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {                
                return Ok(GenerateToken(userInformation));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login Inválido...");
                return BadRequest(ModelState);
            }

        }

        private UserToken GenerateToken(UserModel userInformation)
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

    }
}

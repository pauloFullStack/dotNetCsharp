using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<ApplicationDbContextObjects>(options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 33)), b => b.MigrationsAssembly(typeof(ApplicationDbContextObjects).Assembly.FullName)));

            services.AddDbContextFactory<ApplicationDbContext>(options => options.UseMySql(configuration.GetConnectionString("ConnectionUser"), ServerVersion.AutoDetect(configuration.GetConnectionString("ConnectionUser"))));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //services.AddIdentity<IdentityUser, IdentityRole>(options =>
            //{
            //    options.Password.RequireDigit = false;
            //    options.Password.RequiredLength = 5;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.SignIn.RequireConfirmedAccount = false;

            //}).AddEntityFrameworkStores<ApplicationDbContext>();

            // JWT
            // Adiciona o manipulador de autenticação e define o 
            // esquema de autenticação usado : Bearer
            // valida o emissor, a audiencia e a chave 
            // usando a chave secreta valida a assinatura



            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidAudience = configuration["TokenConfiguration:Audience"],
                        ValidIssuer = configuration["TokenConfiguration:Issuer"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]))
                    }
                );

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = "tokenAspNet"; // Nome personalizado para o cookie
            //    //options.LoginPath = "/login"; // redireciona

            //});

            services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
            {
                options.Cookie.Name = "tokenAspNet"; // Nome personalizado para o cookie
            });

            // Cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        // MUDAR PARA O DOMINIO QUANDO FOR SUBIR PARA PRODUÇÃO
                        builder.WithOrigins("https://localhost:7210")
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials();
                    });
            });


            services.AddAuthorization();

            services.AddCors();

            /* Registrando Repositorys */
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAspNetRolesRepository, AspNetRolesRepository>();

            /* Registrando Services */
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAspNetRolesService, AspNetRolesService>();

            /* Registrando Mapeamento de Entidades para objetos de transferência DTOs */
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            /* Registrando Handlers */
            var myHandlers = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));

            return services;
        }
    }
}

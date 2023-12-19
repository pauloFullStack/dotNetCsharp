
//using BlazorServer.Data;
using Infra.IoC;
using Microsoft.AspNetCore.Components;
using BlazorServer.Utils;
using BlazorServer.Models;
using Microsoft.AspNetCore.Components.Routing;
using BlazorServer.Pages;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ADICIONAR TODOS ESSE SERVIÇOS CASO CRIE OUTRO PROJETO
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddScoped(sp =>
        {
            var navigationManager = sp.GetRequiredService<NavigationManager>();
            return new HttpClient { BaseAddress = new Uri(navigationManager.BaseUri) };
        });

        /* Utils javascript */
        builder.Services.AddScoped<UtilsJavaScript>();
        /* Pega dados do contexto http, cookie, headers... */
        builder.Services.AddScoped<IdentityInformation>();

        builder.Services.AddScoped<AuthenticationValidationService>();

        var app = builder.Build();
        

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }


        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors("AllowSpecificOrigin");

        // Mideleware para ussar controller e api 
        app.MapControllers();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }



}
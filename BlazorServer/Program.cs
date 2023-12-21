
//using BlazorServer.Data;
using Infra.IoC;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using BlazorServer.Pages;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddInfrastructure(builder.Configuration);

        // Serviço que debuga os erro do EF Core
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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
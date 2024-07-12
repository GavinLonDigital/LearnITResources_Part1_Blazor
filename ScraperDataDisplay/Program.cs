using Microsoft.EntityFrameworkCore;
using ScraperDataDisplay.Components;
using ScraperDataDisplay.Data;
using ScraperDataDisplay.Services;

namespace ScraperDataDisplay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var sqlConnectionString = builder.Configuration.GetConnectionString("ScrapeCaptureDbContext");

            builder.Services.AddDbContext<ScrapeCaptureDbContext>(options => options.UseSqlServer(sqlConnectionString));

            builder.Services.AddScoped<ITIOBEService, TIOBEService>();
            builder.Services.AddScoped<IAmazonService, AmazonService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}

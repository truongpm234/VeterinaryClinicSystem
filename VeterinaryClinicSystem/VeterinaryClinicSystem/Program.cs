using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using SignalRLab;
using System.Text;

namespace VeterinaryClinicSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            builder.Services.AddDbContext<VeterinaryClinicSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20); // Set session timeout
                options.Cookie.HttpOnly = true; // For security
                options.Cookie.IsEssential = true; // Ensure session cookie is always created
            });

            builder.Services.AddSignalR();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.MapGet("/", context =>
            {
                context.Response.Redirect("/Authentication/Login");
                return Task.CompletedTask;
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapFallbackToPage("/Authentication/Login");

            app.MapHub<SignalrServer>("/signalRServer");

            app.MapRazorPages();

            app.UseSession();

            app.Run();
        }
    }
}

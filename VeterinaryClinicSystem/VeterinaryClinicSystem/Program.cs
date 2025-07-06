using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repository;
using Service;
using Services;
using SignalRLab;
using System.Text;
using VeterinaryClinicSystem.Repositories;

namespace VeterinaryClinicSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<AppointmentDAO>();
            // Xác thực, người dùng, blog, dịch vụ, bác sĩ (giữ nguyên của bạn)
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IServicesService, ServicesService>();
            builder.Services.AddScoped<IServicesRepository, ServicesRepository>();
            builder.Services.AddScoped<IDoctorsService, DoctorsService>();
            builder.Services.AddScoped<IDoctorsRepository, DoctorsRepository>();
            builder.Services.AddScoped<IBlogPostsService, BlogPostsService>();
            builder.Services.AddScoped<IBlogPostsRepository, BlogPostsRepository>();


            builder.Services.AddScoped<IMedicationsService, MedicationsService>();

            builder.Services.AddScoped<IMedicationsRepository, MedicationsRepository>();

            builder.Services.AddScoped<IInventoryTransactionRepository, InventoryTransactionRepository>();

            builder.Services.AddScoped<IInventoryTransactionService, InventoryTransactionService>();





            builder.Services.AddDbContext<VeterinaryClinicSystemContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            // Session, SignalR, Authorization (giữ nguyên của bạn)
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            builder.Services.AddSignalR();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAuthorization();

            // * Thêm cho Appointment & Email *
            // Cấu hình Smtp
            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));
            builder.Services.AddSingleton<IEmailHelper, EmailHelper>();
            // Repository & Service cho Appointment
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<AppointmentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // Map các endpoint
            app.MapFallbackToPage("/Authentication/Login");
            app.MapHub<SignalrServer>("/signalRServer");
            app.MapRazorPages();
            app.UseSession();

            app.Run();
        }
    }
}
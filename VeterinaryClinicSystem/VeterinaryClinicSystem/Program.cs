using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using SignalRLab;
using System.Text;
using VeterinaryClinicSystem.Extension;

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

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<IServicesService, ServicesService>(); 

            builder.Services.AddScoped<IServicesRepository, ServicesRepository>();

            builder.Services.AddScoped<IDoctorsRepository, DoctorsRepository>();

            builder.Services.AddScoped<IDoctorsService, DoctorsService>();

            builder.Services.AddScoped<IBlogPostsService, BlogPostsService>();

            builder.Services.AddScoped<IBlogPostsRepository, BlogPostsRepository>();

            builder.Services.AddScoped<IEmailHelper, EmailHelper>();

            builder.Services.AddScoped<IMedicationsService, MedicationsService>();

            builder.Services.AddScoped<IMedicationsRepository, MedicationsRepository>();

            builder.Services.AddScoped<IInventoryTransactionRepository, InventoryTransactionRepository>();

            builder.Services.AddScoped<IInventoryTransactionService, InventoryTransactionService>();

            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            builder.Services.AddScoped<IAppointmentService, AppointmentService>();

            builder.Services.AddScoped<IPetRepository, PetRepository>();

            builder.Services.AddScoped<IPetService, PetService>();

            builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();

            builder.Services.AddScoped<IDashboardService, DashboardService>();

            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            builder.Services.AddScoped<IAppointmentService, AppointmentService>();

            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();

            builder.Services.AddScoped<IFeedbackService, FeedbackService>();

            builder.Services.AddScoped<IDoctorDashboardService, DoctorDashboardService>();

            builder.Services.AddScoped<IDoctorDashboardRepository, DoctorDashboardRepository>();

            builder.Services.AddScoped<ICareScheduleRepository, CareScheduleRepository>();

            builder.Services.AddScoped<ICareScheduleService, CareScheduleService>();











            builder.Services.AddDbContext<VeterinaryClinicSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            //builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20); // Set session timeout
                options.Cookie.HttpOnly = true; // For security
                options.Cookie.IsEssential = true; // Ensure session cookie is always created
            });

            builder.Services.AddSignalR();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthorization();

            builder.Services.Configure<SmtpSettings>(
                builder.Configuration.GetSection("SmtpSettings")
            );

            var app = builder.Build();
            
            //new

            //app.MapGet("/", context =>     //set default page khi run
            //{
            //    context.Response.Redirect("/Authentication/Login");
            //    return Task.CompletedTask;
            //});

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapFallbackToPage("/Authentication/Login");

            app.MapHub<SignalrServer>("/signalRServer");

            app.MapHub<AppointmentHub>("/appointmentHub");

            app.MapRazorPages();



            app.Run();
        }
    }
}

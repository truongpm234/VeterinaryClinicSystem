using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using DataAccessLayer;
using Service;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinicSystem.Helpers;
namespace VeterinaryClinicSystem.Pages.Customers
{
    public class CreateAppointmentModel : PageModel
    {
        private readonly VeterinaryClinicSystemContext _context;
        private readonly IEmailHelper _emailHelper;

        public CreateAppointmentModel(
            VeterinaryClinicSystemContext context,
            IEmailHelper emailHelper)
        {
            _context = context;
            _emailHelper = emailHelper;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public SelectList DoctorList  { get; set; }
        public SelectList ServiceList { get; set; }
        public SelectList PetList     { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToPage("/Authentication/Login");

            await PopulateSelectListsAsync(userId.Value);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToPage("/Authentication/Login");

            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync(userId.Value);
                return Page();
            }

            Appointment.OwnerId   = userId.Value;
            Appointment.CreatedAt = DateTime.UtcNow;

            _context.Appointments.Add(Appointment);
            await _context.SaveChangesAsync();

            // Gửi email xác nhận
            var owner   = await _context.Users.FindAsync(Appointment.OwnerId);
            var doctor  = await _context.Users.FindAsync(Appointment.DoctorId);
            var service = await _context.Services.FindAsync(Appointment.ServiceId);
            var pet     = await _context.Pets.FindAsync(Appointment.PetId);

            string htmlBody = $@"
                <p>Chào {owner.FullName},</p>
                <p>Bạn đã đặt lịch với bác sĩ <strong>{doctor.FullName}</strong></p>
                <p>Dịch vụ: {service.Name}</p>
                <p>Vật nuôi: {pet.Name}</p>
                <p>Thời gian: {Appointment.AppointmentDate:dd/MM/yyyy HH:mm}</p>
                <p>Cám ơn bạn!</p>";

            bool sent = await _emailHelper.SendEmailAsync(owner.Email, "Xác nhận lịch hẹn", htmlBody);
            TempData[sent ? "Message" : "Error"] = sent
                ? "Đặt lịch thành công. Email xác nhận đã được gửi."
                : "Đặt lịch thành công nhưng gửi email thất bại.";

            return RedirectToPage("Appointments");
        }

        private async Task PopulateSelectListsAsync(int userId)
        {
            var doctors = await _context.Users
                .Where(u => u.RoleId == 3 && u.IsActive)
                .Select(u => new { u.UserId, u.FullName })
                .ToListAsync();
            DoctorList = new SelectList(doctors, "UserId", "FullName");

            var services = await _context.Services
           .Select(s => new { s.ServiceId, s.Name })
           .ToListAsync();
            ServiceList = new SelectList(services, "ServiceId", "Name");

            var pets = await _context.Pets
         .Select(p => new { p.PetId, p.Name })
         .ToListAsync();
            PetList = new SelectList(pets, "PetId", "Name");
        }
    }
}


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

        public CreateAppointmentModel(VeterinaryClinicSystemContext context, IEmailHelper emailHelper)
        {
            _context = context;
            _emailHelper = emailHelper;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public SelectList DoctorList { get; set; }
        public SelectList OwnerList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await PopulateSelectListsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync();
                return Page();
            }

            // Bởi vì Appointment.DoctorId FK tới bảng Doctors, cần đảm bảo bác sĩ tồn tại
            if (!await _context.Doctors.AnyAsync(d => d.DoctorId == Appointment.DoctorId))
            {
                // Tạo bản ghi Doctors mới liên quan đến Users
                var userDoctor = await _context.Users.FindAsync(Appointment.DoctorId);
                if (userDoctor != null)
                {
                    _context.Doctors.Add(new Doctor { DoctorId = userDoctor.UserId });
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("Appointment.DoctorId", "Bác sĩ không hợp lệ.");
                    await PopulateSelectListsAsync();
                    return Page();
                }
            }

            _context.Appointments.Add(Appointment);
            await _context.SaveChangesAsync();

            // Send confirmation email
            var owner = await _context.Users.FindAsync(Appointment.OwnerId);
            var doctor = await _context.Users.FindAsync(Appointment.DoctorId);
            string htmlBody = $@"
                <p>Chào {owner.FullName},</p>
                <p>Bạn đã đặt lịch với bác sĩ <strong>{doctor.FullName}</strong></p>
                <p>Thời gian: {Appointment.AppointmentDate:dd/MM/yyyy HH:mm}</p>
                <p>Cám ơn bạn!</p>";

            bool sent = await _emailHelper.SendEmailAsync(owner.Email, "Xác nhận lịch hẹn", htmlBody);
            TempData[sent ? "Message" : "Error"] = sent
                ? "Đặt lịch thành công. Email xác nhận đã được gửi."
                : "Đặt lịch thành công nhưng gửi email thất bại.";

            return RedirectToPage("Appointments");
        }

        private async Task PopulateSelectListsAsync()
        {
            var doctors = await _context.Users
                .Where(u => u.RoleId == 3 && u.IsActive)
                .Select(u => new { u.UserId, u.FullName })
                .ToListAsync();
            if (!doctors.Any())
                ModelState.AddModelError(string.Empty, "Chưa có bác sĩ trong hệ thống.");
            DoctorList = new SelectList(doctors, "UserId", "FullName");

            var owners = await _context.Users
                .Where(u => u.RoleId != 3)
                .Select(u => new { u.UserId, u.FullName })
                .ToListAsync();
            OwnerList = new SelectList(owners, "UserId", "FullName");
        }
    }
}



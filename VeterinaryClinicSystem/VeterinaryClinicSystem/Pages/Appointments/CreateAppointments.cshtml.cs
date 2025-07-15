using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service;
using System;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinicSystem.Extension;

namespace VeterinaryClinicSystem.Pages.Appointments
{
    public class CreateAppointmentModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IEmailHelper _emailHelper;
        private readonly VeterinaryClinicSystemContext _context;
        public CreateAppointmentModel(IAppointmentService appointmentService, IEmailHelper emailHelper, VeterinaryClinicSystemContext context)
        {
            _appointmentService = appointmentService;
            _emailHelper = emailHelper;
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? DoctorIdFromRoute { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? ServiceIdFromRoute { get; set; }
        public SelectList DoctorList { get; set; }
        public SelectList ServiceList { get; set; }
        public SelectList PetList { get; set; }
        public List<(User user, BusinessObject.Doctor doctor)> Doctors { get; set; }
        private async Task LoadDoctorCardsAsync()
        {
            var doctors = await _context.Users
                .Where(u => u.RoleId == 3 && u.IsActive)
                .Join(_context.Doctors,
                      u => u.UserId,
                      d => d.DoctorId,
                      (u, d) => new { user = u, doctor = d })
                .ToListAsync();

            Doctors = doctors.Select(d => (d.user, d.doctor)).ToList();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Appointment = new Appointment();

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToPage("/Authentication/Login");

            await PopulateSelectListsAsync(userId.Value);

            if (!DoctorIdFromRoute.HasValue)
            {
                await LoadDoctorCardsAsync();
            }

            if (DoctorIdFromRoute.HasValue)
            {
                Appointment.DoctorId = DoctorIdFromRoute.Value;

                // Đảm bảo DoctorList chứa mục phù hợp để hiển thị tên bác sĩ
                if (!DoctorList.Any(d => d.Value == DoctorIdFromRoute.Value.ToString()))
                {
                    var doctor = await _appointmentService.GetDoctorSelectListAsync();
                    var doctorItem = doctor.FirstOrDefault(d => d.Value == DoctorIdFromRoute.Value.ToString());
                    if (doctorItem != null)
                    {
                        var newList = doctor.ToList();
                        newList.Insert(0, doctorItem); // hoặc Add nếu không có
                        DoctorList = new SelectList(newList, "Value", "Text");
                    }
                }
            }
            if (ServiceIdFromRoute.HasValue)
                Appointment.ServiceId = ServiceIdFromRoute.Value;

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
            if (Appointment.Shift is null || Appointment.Shift < 1 || Appointment.Shift > 5)
            {
                ModelState.AddModelError("Appointment.Shift", "Vui lòng chọn ca làm hợp lệ.");
                await PopulateSelectListsAsync(userId.Value);
                return Page();
            }
            if (DoctorIdFromRoute.HasValue)
            {
                Appointment.DoctorId = DoctorIdFromRoute.Value;
            }
            Appointment.OwnerId = userId.Value;
            Appointment.CreatedAt = DateTime.UtcNow;
            Appointment.Status = "Đang xử lý";

            await _appointmentService.AddAsync(Appointment);

            // Gửi email xác nhận
            var owner = await _context.Users.FindAsync(Appointment.OwnerId);

            if (string.IsNullOrWhiteSpace(owner?.Email))
            {
                TempData["Error"] = "Không thể gửi email vì tài khoản không có địa chỉ email.";
                return RedirectToPage("/Index");
            }
            var doctor = await _context.Users.FindAsync(Appointment.DoctorId);
            var service = await _context.Services.FindAsync(Appointment.ServiceId);
            var pet = await _context.Pets.FindAsync(Appointment.PetId);

            string htmlBody = $@"
    <p>Chào {owner.FullName},</p>
    <p>Bạn đã đặt lịch với bác sĩ <strong>{doctor.FullName}</strong></p>
    <p>Dịch vụ: {service.Name}</p>
    <p>Vật nuôi: {pet.Name}</p>
    <p>Thời gian: {Appointment.AppointmentDate}</p>
    <p>Cám ơn bạn!</p>";

            bool sent = await _emailHelper.SendEmailAsync(owner.Email, "Xác nhận lịch hẹn", htmlBody);
            TempData[sent ? "Message" : "Error"] = sent
                ? "Đặt lịch thành công. Email xác nhận đã được gửi."
                : "Đặt lịch thành công nhưng gửi email thất bại.";

            return RedirectToPage("/Index");
        }

        private async Task PopulateSelectListsAsync(int userId)
        {
            DoctorList = new SelectList(await _appointmentService.GetDoctorSelectListAsync(), "Value", "Text");
            ServiceList = new SelectList(await _appointmentService.GetServiceSelectListAsync(), "Value", "Text");
            PetList = new SelectList(await _appointmentService.GetPetSelectListByOwnerAsync(userId), "Value", "Text");
        }
    }
}

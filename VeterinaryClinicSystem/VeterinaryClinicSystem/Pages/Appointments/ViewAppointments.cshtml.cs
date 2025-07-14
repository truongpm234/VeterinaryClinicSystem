using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity.UI.Services;
using VeterinaryClinicSystem.AppointmentServices;

namespace VeterinaryClinicSystem.Pages.Appointments
{
    public class ViewAppointmentsModel : PageModel
    {
        private readonly IAppointmentService _svc;
        private const int PageSize = 10;
        public ViewAppointmentsModel(IAppointmentService svc)
            => _svc = svc;

        public List<Appointment> AppointmentsList { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; private set; }

        public async Task OnGetAsync()
        {
            var all = await _svc.GetAllAsync();
            var count = all.Count;
            TotalPages = (int)System.Math.Ceiling(count / (double)PageSize);

            AppointmentsList = all
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }

        public async Task<IActionResult> OnPostAcceptAsync(int appointmentId)
        {
            await _svc.AcceptAsync(appointmentId, "Đặt lịch thành công");
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostRejectAsync(int appointmentId)
        {
            await _svc.AcceptAsync(appointmentId, "Từ chối hẹn");
            return RedirectToPage();
        }
    }
}

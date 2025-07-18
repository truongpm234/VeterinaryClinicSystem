using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VeterinaryClinicSystem.Pages.Appointments
{
    public class HistoryModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public HistoryModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public List<Appointment> AppointmentHistory { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            if (UserId <= 0)
            {
                var userIdFromSession = HttpContext.Session.GetInt32("UserId");
                if (userIdFromSession == null)
                {
                    return RedirectToPage("/Index");
                }
                UserId = userIdFromSession.Value;
            }

            AppointmentHistory = await _appointmentService.GetAppointmentsByUserAsync(UserId);
            return Page();
        }
    }
}

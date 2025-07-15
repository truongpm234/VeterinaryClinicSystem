using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace VeterinaryClinicSystem.Pages.Doctor
{
    public class DoctorDashboardModel : PageModel
    {
        private readonly IDoctorDashboardService _dashboardService;

        public List<DoctorDashboard> TodayAppointments { get; set; }
        public List<DoctorDashboard> OngoingCases { get; set; }

        public DoctorDashboardModel(IDoctorDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult OnGet()
        {
            int? accountId = HttpContext.Session.GetInt32("Account");
            if (accountId == null || HttpContext.Session.GetString("Role") != "Doctor")
            {
                return RedirectToPage("/Authentication/Login"); 
                
            }

            int doctorId = accountId.Value;

            TodayAppointments = _dashboardService.GetTodayAppointments(doctorId);
            OngoingCases = _dashboardService.GetOngoingCases(doctorId);

            return Page();
        }

    }
}

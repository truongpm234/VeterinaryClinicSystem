using BusinessObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace VeterinaryClinicSystem.Pages.Doctor
{
    public class DoctorDashboardModel : PageModel
    {
        private readonly DoctorDashboardService _dashboardService;

        public List<DoctorDashboardItem> TodayAppointments { get; set; }
        public List<DoctorDashboardItem> OngoingCases { get; set; }

        public DoctorDashboardModel(DoctorDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public void OnGet()
        {
            int? accountId = HttpContext.Session.GetInt32("Account");
            if (accountId == null || HttpContext.Session.GetString("Role") != "Doctor")
            {
                RedirectToPage("/Authentication/Login"); // ng?n không ?úng role
                return;
            }

            int doctorId = accountId.Value;

            TodayAppointments = _dashboardService.GetTodayAppointments(doctorId);
            OngoingCases = _dashboardService.GetOngoingCases(doctorId);
        }

    }
}

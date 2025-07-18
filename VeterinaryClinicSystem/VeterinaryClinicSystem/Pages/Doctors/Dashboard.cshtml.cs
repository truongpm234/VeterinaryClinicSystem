using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace VeterinaryClinicSystem.Pages.Doctor
{
    public class DashboardModel : PageModel
    {
        private readonly DoctorDashboardService _dashboardService;

        public List<DoctorDashboardItem> TodayAppointments { get; set; }
        public List<DoctorDashboardItem> OngoingCases { get; set; }

        public DashboardModel(DoctorDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public void OnGet()
        {
            int doctorId = 1; // sau này l?y t? login session
            TodayAppointments = _dashboardService.GetTodayAppointments(doctorId);
            OngoingCases = _dashboardService.GetOngoingCases(doctorId);
        }
    }
}

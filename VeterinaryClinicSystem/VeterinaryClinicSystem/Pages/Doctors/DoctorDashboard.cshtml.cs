using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Service;

namespace VeterinaryClinicSystem.Pages.Doctor
{
    public class DoctorDashboardModel : PageModel
    {
        private readonly IDashboardService _dashboardService;

        public DoctorDashboardModel(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public List<DoctorDashboardItem> TodayAppointments { get; set; } = new();
        public List<DoctorDashboardItem> OngoingCases { get; set; } = new();

        public void OnGet()
        {
            int doctorId = 1; // Tạm hardcode để test
            TodayAppointments = _dashboardService.GetTodayAppointments(doctorId);
            OngoingCases = _dashboardService.GetOngoingCases(doctorId);
        }
    }
}

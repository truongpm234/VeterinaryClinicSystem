using BusinessObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service; // Ensure this namespace is correct and contains DashboardService

namespace VeterinaryClinicSystem.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly IDashboardService _dashboardService; // Changed to interface type

        public DashboardStats Stats { get; set; }

        public DashboardModel(IDashboardService dashboardService) // Updated constructor parameter type
        {
            _dashboardService = dashboardService;
        }

        public void OnGet()
        {
            Stats = _dashboardService.GetDashboardStats();
        }
    }
}

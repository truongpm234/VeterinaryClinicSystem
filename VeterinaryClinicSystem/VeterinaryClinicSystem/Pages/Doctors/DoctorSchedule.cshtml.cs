using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace VeterinaryClinicSystem.Pages.Doctors
{
    public class DoctorScheduleModel : PageModel
    {
        private readonly IDoctorDashboardService _dashboardService;

        public DoctorScheduleModel(IDoctorDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public List<DoctorWorkScheduleItem> MonthlySchedule { get; set; } = new();

        public IActionResult OnGet()
        {
            int? accountId = HttpContext.Session.GetInt32("Account");
            if (accountId == null || HttpContext.Session.GetString("Role") != "Doctor")
            {
                return RedirectToPage("/Authentication/Login");
            }

            int doctorId = accountId.Value;
            MonthlySchedule = _dashboardService.GetMonthlySchedule(doctorId);

            return Page();
        }
    }

}

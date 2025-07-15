using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace VeterinaryClinicSystem.Pages.Staff
{
    public class ViewAppointmentsModel : PageModel
    {
        private readonly IAppointmentService _appointment;

        public ViewAppointmentsModel(IAppointmentService appointment)
        {
            _appointment = appointment;
        }

        public List<Appointment> AppointmentsList { get; set; } = new();
        public List<(DoctorSchedule Schedule, string DoctorName)> SchedulesWithDoctorName { get; set; } = new();

        public async Task OnGetAsync()
        {
            AppointmentsList = await _appointment.GetAllAppointmentsAsync();
            SchedulesWithDoctorName = await _appointment.GetDoctorSchedulesWithNamesAsync();
        }

        public async Task<IActionResult> OnPostAcceptAsync(int appointmentId)
        {
            var success = await _appointment.AcceptAppointmentAsync(appointmentId);
            if (!success)
            {
                TempData["Error"] = "Ca làm này đã có người đặt.";
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRejectAsync(int appointmentId)
        {
            await _appointment.RejectAppointmentAsync(appointmentId);
            return RedirectToPage();
        }
    }
}

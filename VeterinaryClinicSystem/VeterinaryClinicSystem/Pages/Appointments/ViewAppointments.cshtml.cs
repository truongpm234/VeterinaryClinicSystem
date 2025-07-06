using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace VeterinaryClinicSystem.Pages.Appointments
{
    public class ViewAppointmentsModel : PageModel
    {
        private readonly AppointmentService _svc;
        public ViewAppointmentsModel(AppointmentService svc) => _svc = svc;

        public List<Appointment> AppointmentsList { get; set; }

        // Khi trang được GET
        public async Task OnGetAsync()
        {
            AppointmentsList = await _svc.GetAllAsync();
        }
    }
}

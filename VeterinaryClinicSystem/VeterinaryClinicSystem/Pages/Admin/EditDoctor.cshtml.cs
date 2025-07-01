using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using BusinessObject;
using Microsoft.AspNetCore.SignalR;
using SignalRLab;

namespace VeterinaryClinicSystem.Pages.Admin
{
    public class EditDoctorModel : PageModel
    {
        private readonly IDoctorsService _doctorService;
        private readonly IHubContext<SignalrServer> _hubContext;

        public EditDoctorModel(IDoctorsService doctorService, IHubContext<SignalrServer> hubContext)
        {
            _doctorService = doctorService;
            _hubContext = hubContext;
        }

        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public Doctor Doctor { get; set; }

        public IActionResult OnGet(int id)
        {
            var data = _doctorService.GetDoctorByUserId(id);
            if (data.user == null) return RedirectToPage("/Admin/ManagePage", new { section = "doctors" });
            User = data.user;
            Doctor = data.doctor;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _doctorService.UpdateDoctor(Doctor, User.FullName);

            TempData["Message"] = "Update Successfully!!";

            _hubContext.Clients.All.SendAsync("LoadAllItems");

            return RedirectToPage("/Admin/ManagePage", new { section = "doctors" });
        }
    }
}
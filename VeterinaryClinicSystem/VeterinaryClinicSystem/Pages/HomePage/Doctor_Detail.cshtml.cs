using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace VeterinaryClinicSystem.Pages.HomePage
{
    public class Doctor_DetailModel : PageModel
    {
        private readonly IDoctorsService _doctorService;

        public Doctor_DetailModel(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        public User UserInfo { get; set; }
        public BusinessObject.Doctor DoctorInfo { get; set; }

        public IActionResult OnGet(int id)
        {
            var doctor = _doctorService.GetDoctorByUserId(id);

            if (doctor is (var user, var doc))
            {
                UserInfo = user;
                DoctorInfo = doc;
                return Page();
            }
            return NotFound();

        }

    }
}

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

        public List<(User user, Doctor doctor)> Doctors { get; set; }

        public void OnGet()
        {
            Doctors = _doctorService.GetAllDoctors();
        }
    }
}

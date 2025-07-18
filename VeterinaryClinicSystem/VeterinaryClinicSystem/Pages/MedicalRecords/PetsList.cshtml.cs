using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace VeterinaryClinicSystem.Pages.MedicalRecords
{
    public class PetsListModel : PageModel
    {
        public List<Pet> Pets { get; set; } = new();

        public void OnGet()
        {
            int? doctorId = HttpContext.Session.GetInt32("Account");
            if (doctorId == null)
            {
                Pets = new List<Pet>();
                return;
            }

            Pets = MedicalRecordsDAO.GetPetsWithAppointmentsTodayForDoctor(doctorId.Value);
        }

    }


}

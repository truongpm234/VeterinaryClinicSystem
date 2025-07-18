using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VeterinaryClinicSystem.Pages.MedicalRecords
{
    public class PetsListModel : PageModel
    {
        public List<Pet> Pets { get; set; } = new();

        public void OnGet()
        {
            var allPets = PetDAO.GetAllPets();

            var today = DateTime.Today;

            Pets = allPets
                .Where(p => p.Appointments.Any(a =>
                    a.AppointmentDate.HasValue &&
                    a.AppointmentDate.Value.Date == today &&
                    a.Status == "??t l?ch thành công"))
                .ToList();
        }
    }

}

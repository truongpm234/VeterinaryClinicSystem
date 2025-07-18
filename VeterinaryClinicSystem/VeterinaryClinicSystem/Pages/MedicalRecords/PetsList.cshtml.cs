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
            Pets = PetDAO.GetAllPets();
        }
    }


}

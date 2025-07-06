using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using DataAccessLayer;

namespace VeterinaryClinicSystem.Pages.Pets
{
    public class IndexModel : PageModel
    {
        public List<Pet> Pets { get; set; } = new();

        public void OnGet()
        {
            Pets = PetDAO.GetAllPets();
        }
    }

}

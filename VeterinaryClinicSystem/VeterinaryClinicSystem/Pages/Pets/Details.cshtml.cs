using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using DataAccessLayer;


namespace VeterinaryClinicSystem.Pages.Pets
{
    public class DetailsModel : PageModel
    {
        public Pet Pet { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            var pet = PetDAO.GetPetById(id);
            if (pet == null)
                return NotFound();

            Pet = pet;
            return Page();
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using DataAccessLayer;


namespace VeterinaryClinicSystem.Pages.Pets
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Pet Pet { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            var pet = PetDAO.GetPetById(id);
            if (pet == null)
                return NotFound();

            Pet = pet;
            return Page();
        }

        public IActionResult OnPost()
        {
            PetDAO.DeletePet(Pet.PetId);
            return RedirectToPage("Index");
        }
    }

}

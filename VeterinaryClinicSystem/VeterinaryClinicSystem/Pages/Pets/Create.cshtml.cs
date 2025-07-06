using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VeterinaryClinicSystem.Pages.Pets
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Pet Pet { get; set; } = default!;

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            PetDAO.AddPet(Pet);
            return RedirectToPage("Index");
        }
    }

}

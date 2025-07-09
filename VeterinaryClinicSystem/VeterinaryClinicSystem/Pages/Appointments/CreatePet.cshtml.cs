using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VeterinaryClinicSystem.Pages.Customers
{
    public class CreatePetModel : PageModel
    {
        private readonly VeterinaryClinicSystemContext _context;
        public CreatePetModel(VeterinaryClinicSystemContext context) => _context = context;

        [BindProperty]
        public Pet Pet { get; set; }
        public string ReturnPage { get; set; }

        public void OnGet(string returnPage)
        {
            ReturnPage = returnPage;
        }

        public async Task<IActionResult> OnPostAsync(string returnPage)
        {
            if (!ModelState.IsValid) return Page();
            await _context.Pets.AddAsync(Pet);
            await _context.SaveChangesAsync();

            // Quay lại CreateAppointment với pet mới
            return RedirectToPage("CreateAppointment", new { newPetId = Pet.PetId });
        }
    }
}
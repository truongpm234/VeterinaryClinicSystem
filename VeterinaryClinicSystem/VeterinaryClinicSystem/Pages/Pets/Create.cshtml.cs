using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace VeterinaryClinicSystem.Pages.Pets
{
    public class CreateModel : PageModel
    {
        private readonly VeterinaryClinicSystemContext _context;

        public CreateModel(VeterinaryClinicSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pet Pet { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToPage("/Authentication/Login");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToPage("/Authentication/Login");

            if (!ModelState.IsValid)
                return Page();

            Pet.OwnerId = userId.Value;                      
            Pet.CreatedAt = DateTime.UtcNow;                 

            _context.Pets.Add(Pet);
            await _context.SaveChangesAsync();

            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToPage("/Pets/Index");
        }

    }
}

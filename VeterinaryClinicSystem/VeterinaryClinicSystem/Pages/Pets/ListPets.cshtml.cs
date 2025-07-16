using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using DataAccessLayer;
using System.Collections.Generic;

namespace VeterinaryClinicSystem.Pages.Pets
{
    public class ListPetsModel : PageModel
    {
        public List<Pet> Pets { get; set; } = new();

        public string UserName { get; set; } = "";
        public int PetCount { get; set; }

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToPage("/Authentication/Login");
            Pets = PetDAO.GetAllPets()
                         .FindAll(p => p.OwnerId == userId.Value);
            PetCount = Pets.Count;
            UserName = HttpContext.Session.GetString("FullName") ?? "Bạn";

            return Page();
        }
    }
}
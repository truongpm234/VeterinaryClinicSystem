using BusinessObject;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using IAuthenticationService = Service.IAuthenticationService;
namespace VeterinaryClinicSystem.Pages.Authentication
{
    public class RegisterModel : PageModel
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnPost()
        {
            try
            {
                _authenticationService.CreateUser(User);
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.InnerException?.Message ?? ex.Message);
                return Page();
            }

        }
    }

}

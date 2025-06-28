using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Service;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace VeterinaryClinicSystem.Pages.Authentication
{
    public class LoginModel : PageModel
    {

        private Service.IAuthenticationService _authenticationService;
        public LoginModel(Service.IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var loginId = HttpContext.Session.GetInt32("Account").ToString();
            if (!string.IsNullOrEmpty(loginId))
            {
                return RedirectToPage("/Privacy");
                

            }
            return Page();

        }

        [BindProperty]
        public User User { get; set; } = default!;
        public string Message { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var userAccount = _authenticationService.GetUserByEmail(User.Email);

            if (userAccount == null)
            {
                Message = "Account is not exist!";
                ModelState.AddModelError(string.Empty, Message);
                return Page();
            }

            if (userAccount.PasswordHash != User.PasswordHash)
            {
                Message = "Invalid password!";
                ModelState.AddModelError(string.Empty, Message);
                return Page();
            }

            if (userAccount.IsActive == false)
            {
                Message = "Your account has been deactivated!";
                ModelState.AddModelError(string.Empty, Message);
                return Page();
            }
            
            HttpContext.Session.SetInt32("Account", userAccount.UserId);
            HttpContext.Session.SetString("FullName", userAccount.FullName ?? "");
            HttpContext.Session.SetString("Role", userAccount.Role?.RoleName ?? "");

            return RedirectToPage("/Index");
        }
    }
}

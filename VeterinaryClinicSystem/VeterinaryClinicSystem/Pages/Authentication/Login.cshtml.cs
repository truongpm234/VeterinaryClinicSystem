using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Service;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

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
            //var loginId = HttpContext.Session.GetInt32("Account").ToString();
            //if (!string.IsNullOrEmpty(loginId))
            //{
            //    return RedirectToPage("/Authentication/Login");
            //}

            var userAccount = _authenticationService.GetUserByEmail(User.Email);

            if (userAccount == null)
            {
                Message = "Account is not exist!";
                ModelState.AddModelError(string.Empty, Message);

                return Page();
            }
            else if (userAccount.RoleId == 1)
            {
                HttpContext.Session.SetInt32("Account", userAccount.RoleId ?? 0);
                Message = "You are admin.";
           
                return RedirectToPage("/Index");
            }
            else if (userAccount.RoleId == 2)
            {
                HttpContext.Session.SetInt32("Account", userAccount.RoleId ?? 0);
                Message = "You are admin.";
                ModelState.AddModelError(string.Empty, Message);
                return RedirectToPage("/Index");
            }
            else if (userAccount.RoleId == 3)
            {
                HttpContext.Session.SetInt32("Account", userAccount.RoleId ?? 0);
                Message = "You are doctor.";
                ModelState.AddModelError(string.Empty, Message);
                return RedirectToPage("/Index");
            }
            else if (userAccount.RoleId == 4)
            {
                HttpContext.Session.SetInt32("Account", userAccount.RoleId ?? 0);
                Message = "You are staff.";
                ModelState.AddModelError(string.Empty, Message);
                return RedirectToPage("/Index");
            }
            else
            {
                Message = "You are customer.";
                ModelState.AddModelError(string.Empty, Message);
                return Page();
            }
        }

    }
}

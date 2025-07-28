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

        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        public LoginModel(IAuthenticationService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var loginId = HttpContext.Session.GetInt32("Account");
            var roleName = HttpContext.Session.GetString("Role");

            if (loginId != null)
            {
                if (roleName == "Admin")
                {
                    return RedirectToPage("/Admin/ManageUsers");
                }
                if (roleName == "Manager")
                {
                    return RedirectToPage("/Managers/Profile");
                }
                if (roleName == "Doctor")
                {
                    return RedirectToPage("/Doctors/Profile");
                }
                if (roleName == "Staff")
                {
                    return RedirectToPage("/Staff/ViewAppointments");
                }
                if (roleName == "Customer")
                {
                    return RedirectToPage("/Appointments/CreateAppointments");
                }

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
                var admin = _userService.GetAllUsers().FirstOrDefault(u => u.RoleId == 1);
                var adminEmail = admin?.Email;
                Message = $"Your account has been deactivated! Please contact the admin via {adminEmail} for support.";
                ModelState.AddModelError(string.Empty, Message);
                return Page();
            }
            
            HttpContext.Session.SetInt32("Account", userAccount.UserId);
            HttpContext.Session.SetString("FullName", userAccount.FullName ?? "");
            HttpContext.Session.SetInt32("RoleId", userAccount.RoleId ?? 0);
            HttpContext.Session.SetString("Role", userAccount.Role?.RoleName ?? "");
            HttpContext.Session.SetString("AvatarUrl", userAccount.AvatarUrl ?? "/images/default-avatar.png");
            HttpContext.Session.SetInt32("UserId", userAccount.UserId);
            HttpContext.Session.SetInt32("RoleId", userAccount.RoleId ?? 0);
            HttpContext.Session.SetString("Email", userAccount.Email);

            return RedirectToPage("/Index");
        }
    }
}

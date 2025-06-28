using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace VeterinaryClinicSystem.Pages.Profile
{
    public class ProfileModel : PageModel
    {
        private readonly IUserService _userService;

        public ProfileModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetInt32("Account");
            if (userId == null) return RedirectToPage("/Authentication/Login");

            User = _userService.GetUserById(userId.Value);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (User.UserId == 0)
            {
                TempData["Message"] = "Invalid User ID.";
                return Page();
            }

            try
            {
                _userService.UpdateUser(User);
                TempData["Message"] = "Updated Successfully!";
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }

            return RedirectToPage();
        }

    }
}

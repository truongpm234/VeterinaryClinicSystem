using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace VeterinaryClinicSystem.Pages.Admin
{
    public class ProfileModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;

        public ProfileModel(IUserService userService, IWebHostEnvironment env)
        {
            _userService = userService;
            _env = env;
        }

        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public BusinessObject.Doctor? Doctor { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool IsEditing { get; set; } = false;
        [BindProperty]
        public IFormFile? AvatarUpload { get; set; }

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetInt32("Account");
            if (userId == null) return RedirectToPage("/Authentication/Login");

            User = _userService.GetUserById(userId.Value);
            return Page();
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("DoctorNavigation");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userIdInSession = HttpContext.Session.GetInt32("Account");
            if (userIdInSession == null)
            {
                return RedirectToPage("/Authentication/Login");
            }

            if (User.UserId != userIdInSession.Value)
            {
                return RedirectToPage();
            }

            try
            {
                if (AvatarUpload != null && AvatarUpload.Length > 0)
                {
                    var fileName = Path.GetFileName(AvatarUpload.FileName);
                    var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsPath))
                    {
                        Directory.CreateDirectory(uploadsPath);
                    }

                    var filePath = Path.Combine(uploadsPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        AvatarUpload.CopyTo(stream);
                    }

                    User.AvatarUrl = "/uploads/" + fileName;
                }

                _userService.UpdateUser(User);
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Error: {ex.Message}";
            }

            return RedirectToPage();
        }

        public IActionResult OnGetEdit()
        {
            var userId = HttpContext.Session.GetInt32("Account");
            if (userId == null) return RedirectToPage("/Authentication/Login");

            User = _userService.GetUserById(userId.Value);

            if (User.UserId != userId)
            {
                return RedirectToPage();
            }

            IsEditing = true;
            return Page();
        }

    }
}

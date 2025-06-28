using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using VeterinaryClinicSystem.Filters;

namespace VeterinaryClinicSystem.Pages.Admin
{
    [AuthorizeFilter("Admin")]
    public class UsersModel : PageModel
    {
        private readonly IUserService _userService;

        public UsersModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = _userService.GetAllUsers();
        }

        public IActionResult OnPostDelete(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostActivateAsync(int id)
        {
            _userService.ActiveUser(id);
            return RedirectToPage();
        }

    }
}

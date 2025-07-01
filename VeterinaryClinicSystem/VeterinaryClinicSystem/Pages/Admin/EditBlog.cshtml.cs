using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using BusinessObject;
using Microsoft.AspNetCore.SignalR;
using SignalRLab;

namespace VeterinaryClinicSystem.Pages.Admin
{
    public class EditBlogModel : PageModel
    {
        private readonly IBlogPostsService _blogService;
        private readonly IHubContext<SignalrServer> _hubContext;

        public EditBlogModel(IBlogPostsService blogService, IHubContext<SignalrServer> hubContext)
        {
            _blogService = blogService;
            _hubContext = hubContext;
        }

        [BindProperty]
        public BlogPost Blog { get; set; }

        public IActionResult OnGet(int id)
        {
            Blog = _blogService.GetById(id);
            if (Blog == null) return RedirectToPage("/Admin/ManagePage", new { section = "blog" });
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _blogService.Update(Blog);
            TempData["Message"] = "Update Successfully!!";

            _hubContext.Clients.All.SendAsync("LoadAllItems");

            return RedirectToPage("/Admin/ManagePage", new { section = "blog" });
        }
    }
}
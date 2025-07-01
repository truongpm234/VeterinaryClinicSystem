using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using BusinessObject;
using Microsoft.AspNetCore.SignalR;
using SignalRLab;

namespace VeterinaryClinicSystem.Pages.Admin.ManagePage
{
    public class EditBlogModel : PageModel
    {
        private readonly IBlogPostsService _blogService;
        private readonly IHubContext<SignalrServer> _hubContext;
        private readonly IWebHostEnvironment _env;

        public EditBlogModel(IBlogPostsService blogService, IHubContext<SignalrServer> hubContext, IWebHostEnvironment env)
        {
            _blogService = blogService;
            _hubContext = hubContext;
            _env = env;
        }

        [BindProperty]
        public BlogPost Blog { get; set; }
        [BindProperty]
        public IFormFile? CoverImage { get; set; }
        public IActionResult OnGet(int id)
        {
            Blog = _blogService.GetById(id);
            if (Blog == null) return RedirectToPage("/Admin/ManagePage/ManagePage", new { section = "blog" });
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (CoverImage != null && CoverImage.Length > 0)
            {
                var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsPath);

                var fileName = Path.GetFileName(CoverImage.FileName);
                var filePath = Path.Combine(uploadsPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    CoverImage.CopyTo(stream);
                }

                Blog.CoverImageUrl = "/uploads/" + fileName;
            }
            _blogService.Update(Blog);
            TempData["Message"] = "Update Successfully!!";

            _hubContext.Clients.All.SendAsync("LoadAllItems");

            return RedirectToPage("/Admin/ManagePage/ManagePage", new { section = "blog" });
        }
    }
}
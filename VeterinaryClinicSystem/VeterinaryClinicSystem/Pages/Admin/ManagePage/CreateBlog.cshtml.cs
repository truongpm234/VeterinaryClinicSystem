using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Service;

namespace VeterinaryClinicSystem.Pages.Admin.ManagePage
{
    public class CreateBlogModel : PageModel
    {
        private readonly IBlogPostsService _blogService;
        private readonly IWebHostEnvironment _env;

        public CreateBlogModel(IBlogPostsService blogService, IWebHostEnvironment env)
        {
            _blogService = blogService;
            _env = env;
        }

        [BindProperty]
        public BlogPost Blog { get; set; }

        [BindProperty]
        public IFormFile? CoverImage { get; set; }

        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Admin") return RedirectToPage("/AccessDenied");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (CoverImage != null)
            {
                var fileName = $"{Guid.NewGuid()}_{CoverImage.FileName}";
                var uploadPath = Path.Combine(_env.WebRootPath, "uploads", "blog");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var filePath = Path.Combine(uploadPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    CoverImage.CopyTo(stream);
                }

                Blog.CoverImageUrl = $"/uploads/blog/{fileName}";
            }

            Blog.CreatedAt = DateTime.Now;
            Blog.UpdatedAt = DateTime.Now;
            if (string.IsNullOrWhiteSpace(Blog.Slug))
            {
                Blog.Slug = Blog.Title?.ToLower().Replace(" ", "-").Replace(",", "").Replace(".", "") ?? Guid.NewGuid().ToString();
            }

            Blog.AuthorId = HttpContext.Session.GetInt32("UserId");

            _blogService.Add(Blog);

            TempData["Message"] = "Blog post created successfully!";
            return RedirectToPage("/Admin/ManagePage/ManagePage", new { section = "blog" });
        }
    }
}

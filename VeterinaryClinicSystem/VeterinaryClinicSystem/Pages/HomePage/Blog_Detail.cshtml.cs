using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace VeterinaryClinicSystem.Pages.HomePage
{
    public class Blog_DetailModel : PageModel
    {
        private readonly IBlogPostsService _blogPostsService;

        public Blog_DetailModel(IBlogPostsService blogPostsService)
        {
            _blogPostsService = blogPostsService;
        }

        public BlogPost? BlogPost { get; set; }

        public IActionResult OnGet(int id)
        {
            BlogPost = _blogPostsService.GetById(id);
            if (BlogPost == null || BlogPost.IsPublished == false)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

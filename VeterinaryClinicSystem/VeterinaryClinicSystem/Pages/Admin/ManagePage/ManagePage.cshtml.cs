using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using BusinessObject;

namespace VeterinaryClinicSystem.Pages.Admin.ManagePage
{
    public class ManagePageModel : PageModel
    {
        private readonly IDoctorsService _doctorService;
        private readonly IServicesService _serviceService;
        private readonly IBlogPostsService _blogService;

        public ManagePageModel(IDoctorsService doctorService, IServicesService serviceService, IBlogPostsService blogService)
        {
            _doctorService = doctorService;
            _serviceService = serviceService;
            _blogService = blogService;
        }

        [BindProperty(SupportsGet = true)]
        public string Section { get; set; } = "";

        public List<(User user, Doctor doctor)> Doctors { get; set; }
        public List<BusinessObject.Service> Services { get; set; }
        public List<BlogPost> BlogPosts { get; set; }

        public IActionResult OnGet()
        {
            var roleName = HttpContext.Session.GetString("Role");
            if (roleName != "Admin") return RedirectToPage("/AccessDenied");

            switch (Section)
            {
                case "doctors":
                    Doctors = _doctorService.GetAllDoctors();
                    break;
                case "services":
                    Services = _serviceService.GetAllServices();
                    break;
                case "blog":
                    BlogPosts = _blogService.GetAllBlogByAdmin();
                    break;
            }

            return Page();
        }
    }
}

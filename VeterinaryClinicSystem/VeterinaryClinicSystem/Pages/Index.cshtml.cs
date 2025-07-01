using BusinessObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Service;
using SignalRLab;

namespace VeterinaryClinicSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IServicesService _serviceService;
        private readonly IDoctorsService _doctorService;
        private readonly IBlogPostsService _blogService;
        private readonly IHubContext<SignalrServer> _hubContext;
        public IndexModel(ILogger<IndexModel> logger, IServicesService serviceService, IDoctorsService doctorService, IBlogPostsService blogPostsService, IHubContext<SignalrServer> hubContext)
        {
            _logger = logger;
            _serviceService = serviceService;
            _doctorService = doctorService;
            _blogService = blogPostsService;
            _hubContext = hubContext;

        }

        public List<BusinessObject.Service> Services { get; set; } = new();
        public List<(User user, Doctor doctor)> Doctors { get; set; } = new();
        public List<BlogPost> BlogPosts { get; set; }

        public void OnGet()
        {
            Services = _serviceService.GetAllServices();
            Doctors = _doctorService.GetAllDoctors();
            BlogPosts = _blogService.GetBlogByPublish();
            _hubContext.Clients.All.SendAsync("LoadAllItems");
        }
    }
}

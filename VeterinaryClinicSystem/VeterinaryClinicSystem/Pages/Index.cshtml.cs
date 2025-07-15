using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
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
        //private readonly DbContext _context; // Added DbContext dependency
        private readonly VeterinaryClinicSystemContext _Context; // Assuming this is your DbContext class

        public IndexModel(ILogger<IndexModel> logger, IServicesService serviceService, IDoctorsService doctorService, IBlogPostsService blogPostsService, IHubContext<SignalrServer> hubContext, VeterinaryClinicSystemContext context)
        {
            _logger = logger;
            _serviceService = serviceService;
            _doctorService = doctorService;
            _blogService = blogPostsService;
            _hubContext = hubContext;
            _Context = context; // Initialize _context
        }

        public List<BusinessObject.Service> Services { get; set; } = new();
        public List<(User user, BusinessObject.Doctor doctor)> Doctors { get; set; } = new();
        public List<BlogPost> BlogPosts { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public void OnGet()
        {
            Services = _serviceService.GetAllServices();
            Doctors = _doctorService.GetAllDoctors();
            BlogPosts = _blogService.GetBlogByPublish();

            //_hubContext.Clients.All.SendAsync("LoadAllItems");

            int pageSize = 3;
            var totalFeedback = _Context.Feedbacks.Count();

            TotalPages = (int)Math.Ceiling(totalFeedback / (double)pageSize);

            
            if (PageNumber < 1) PageNumber = 1;
            if (PageNumber > TotalPages) PageNumber = TotalPages;

            Feedbacks = _Context.Feedbacks
                .Include(f => f.Customer)
                .Include(f => f.Doctor).ThenInclude(d => d.DoctorNavigation)
                .OrderByDescending(f => f.CreatedAt)
                .Take(3)
                .ToList();
        }


        
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        

    }
}

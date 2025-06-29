using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace VeterinaryClinicSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IServicesService _serviceService;

        public IndexModel(ILogger<IndexModel> logger, IServicesService serviceService)
        {
            _logger = logger;
            _serviceService = serviceService;

        }

        public List<BusinessObject.Service> Services { get; set; } = new();

        public void OnGet()
        {
            Services = _serviceService.GetAllServices();
        }
    }
}

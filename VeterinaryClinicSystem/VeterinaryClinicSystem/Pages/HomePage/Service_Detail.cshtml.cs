using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Service;

namespace VeterinaryClinicSystem.Pages.HomePage
{
    public class Service_DetailModel : PageModel
    {
        private readonly IServicesService _serviceService;

        public Service_DetailModel(IServicesService serviceService)
        {
            _serviceService = serviceService;
        }

        public BusinessObject.Service Service { get; set; }

        public IActionResult OnGet(int id)
        {
            Service = _serviceService.GetServiceById(id);
            if (Service == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

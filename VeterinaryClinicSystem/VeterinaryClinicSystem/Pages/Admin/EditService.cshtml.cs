using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using BusinessObject;
using Microsoft.AspNetCore.SignalR;
using SignalRLab;

namespace VeterinaryClinicSystem.Pages.Admin
{
    public class EditServiceModel : PageModel
    {
        private readonly IServicesService _serviceService;
        private readonly IHubContext<SignalrServer> _hubContext;

        public EditServiceModel(IServicesService serviceService, IHubContext<SignalrServer> hubContext)
        {
            _serviceService = serviceService;
            _hubContext = hubContext;
        }

        [BindProperty]
        public BusinessObject.Service Service { get; set; }

        public IActionResult OnGet(int id)
        {
            Service = _serviceService.GetServiceById(id);
            if (Service == null) return RedirectToPage("/Admin/EditService", new { section = "services" });
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _serviceService.UpdateService(Service);
            TempData["Message"] = "Update Successfully!!";
            _hubContext.Clients.All.SendAsync("LoadAllItems");

            return RedirectToPage("/Admin/ManagePage", new { section = "services" });
        }
    }
}
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;
using VeterinaryClinicSystem.Extension;

namespace VeterinaryClinicSystem.Pages.Customers;

public class PetCareScheduleModel : PageModel
{
    private readonly ICareScheduleService _careService;
    private readonly IPetService _petService;
    private readonly IServicesService _serviceService;
    private readonly IEmailHelper _emailHelper;

    public Pet Pet { get; set; }
    public List<CareSchedule> Schedules { get; set; } = [];

    public SelectList ServiceList { get; set; } = default!;

    [BindProperty] public string NewCareType { get; set; } = string.Empty;
    [BindProperty] public DateOnly InitialDate { get; set; }

    public PetCareScheduleModel(
        ICareScheduleService careService,
        IPetService petService,
        IServicesService serviceService,
        IEmailHelper emailHelper)
    {
        _careService = careService;
        _petService = petService;
        _serviceService = serviceService;
        _emailHelper = emailHelper;
    }

    public IActionResult OnGet(int petId)
    {
        Pet = _petService.GetPetById(petId);
        if (Pet == null) return NotFound();

        Schedules = _careService.GetSchedulesByPetId(petId);

        var services = _serviceService.GetAllServices()
            .Where(s => s.Name.Contains("Tiêm phòng"))
            .ToList();

        ServiceList = new SelectList(services, "Name", "Name");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int petId)
    {
        Pet = _petService.GetPetById(petId);
        if (Pet == null) return NotFound();

        var schedule = new CareSchedule
        {
            PetId = petId,
            CareType = NewCareType,
            InitialDate = InitialDate,
            NextDueDate = InitialDate.AddMonths(6),
            IsCompleted = false,
            CreatedAt = DateTime.Now
        };

        _careService.Add(schedule);

        var customerEmail = HttpContext.Session.GetString("Email");
        if (!string.IsNullOrEmpty(customerEmail))
        {
            await _emailHelper.EmailForCareScheduleAsync(Pet, schedule, customerEmail);
        }

        return RedirectToPage(new { petId });
    }
}

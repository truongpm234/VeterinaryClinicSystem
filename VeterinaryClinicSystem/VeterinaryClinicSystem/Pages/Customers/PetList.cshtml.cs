using BusinessObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace VeterinaryClinicSystem.Pages.Customers
{
    public class PetListModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly ICareScheduleService _careScheduleService;

        public List<Pet> Pets { get; set; } = [];
        public Dictionary<int, bool> PetHasSchedule { get; set; } = [];

        public PetListModel(IPetService petService, ICareScheduleService careScheduleService)
        {
            _petService = petService;
            _careScheduleService = careScheduleService;
        }

        public void OnGet()
        {
            int customerId = HttpContext.Session.GetInt32("Account") ?? 0;
            Pets = _petService.GetPetByCustomerId(customerId);

            // Lấy lịch tiêm phòng từng pet
            PetHasSchedule = Pets.ToDictionary(
                pet => pet.PetId,
                pet => _careScheduleService.GetSchedulesByPetId(pet.PetId).Any()
            );
        }
    }
}

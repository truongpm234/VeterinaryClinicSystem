using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service;

namespace VeterinaryClinicSystem.Pages.MedicalRecords
{
    public class CreateModel : PageModel
    {
        private readonly VeterinaryClinicSystemContext _context;
        private readonly IMedicalRecordsService _service;

        public CreateModel(VeterinaryClinicSystemContext context, IMedicalRecordsService service)
        {
            _context = context;
            _service = service;
        }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; }

        public void OnGet()
        {
            // Có thể load dropdown PetId, DoctorId... nếu cần
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            MedicalRecord.CreatedAt = DateTime.Now;

            _service.AddMedicalRecord(MedicalRecord);

            return RedirectToPage("/index"); // Hoặc trang bạn muốn điều hướng về
        }
    }

}

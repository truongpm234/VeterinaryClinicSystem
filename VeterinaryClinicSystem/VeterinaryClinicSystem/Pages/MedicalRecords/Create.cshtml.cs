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

        // Thêm property này để hiển thị tên pet
        public string PetName { get; set; } = string.Empty;

        public void OnGet(int petId)
        {
            // Gán sẵn PetId để form bind
            MedicalRecord = new MedicalRecord
            {
                PetId = petId
            };

            // Truy vấn Pet để lấy tên
            var pet = _context.Pets.FirstOrDefault(p => p.PetId == petId);
            if (pet != null)
            {
                PetName = pet.Name ?? "Unknown";
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            MedicalRecord.CreatedAt = DateTime.Now;

            _service.AddMedicalRecord(MedicalRecord);

            return RedirectToPage("/Pets/Index"); // Quay lại list Pet sau khi tạo
        }
    }


}

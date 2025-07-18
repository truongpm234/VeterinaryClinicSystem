using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VeterinaryClinicSystem.Pages.MedicalRecords
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = new();

        [BindProperty]
        public List<PrescriptionDetail> PrescriptionItems { get; set; } = new();

        public List<Medication> Medications { get; set; } = new();

        public string PetName { get; set; } = "";

        public void OnGet(int? petId)
        {
            if (petId.HasValue)
            {
                var pet = PetDAO.GetPetById(petId.Value);
                if (pet != null)
                {
                    MedicalRecord.PetId = pet.PetId;
                    PetName = pet.Name ?? "";
                }
            }

            Medications = MedicationDAO.GetAllMedications();
        }

        public IActionResult OnPost()
        {
            int? doctorId = HttpContext.Session.GetInt32("Account");
            if (doctorId == null) return RedirectToPage("/Authentication/Login");

            MedicalRecord.DoctorId = doctorId.Value;
            MedicalRecord.AppointmentId = 1;

            // Lưu MedicalRecord trước
            MedicalRecordsDAO.AddMedicalRecord(MedicalRecord);

            // Lưu PrescriptionDetails
            using var context = new VeterinaryClinicSystemContext();
            foreach (var item in PrescriptionItems)
            {
                item.RecordId = MedicalRecord.RecordId; // RecordId đã có sau SaveChanges
                context.PrescriptionDetails.Add(item);
            }
            context.SaveChanges();

            return RedirectToPage("/MedicalRecords/PetsList");
        }
    }


}

using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VeterinaryClinicSystem.Pages.MedicalRecords
{
    public class PetRecordsModel : PageModel
    {
        public List<MedicalRecord> Records { get; set; } = new();
        public string PetName { get; set; } = "";

        public void OnGet(int petId)
        {
            Records = MedicalRecordsDAO.GetMedicalRecordsByPetId(petId);

            if (Records.Count > 0)
            {
                PetName = Records[0].Pet?.Name ?? "";
            }
            else
            {
                // N?u Pet ch?a có MedicalRecord, l?y tên Pet luôn cho an toàn:
                var pet = PetDAO.GetPetById(petId);
                PetName = pet?.Name ?? "";
            }
        }
    }


}

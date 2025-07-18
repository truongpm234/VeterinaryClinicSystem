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
                // N?u Pet ch?a c� MedicalRecord, l?y t�n Pet lu�n cho an to�n:
                var pet = PetDAO.GetPetById(petId);
                PetName = pet?.Name ?? "";
            }
        }
    }


}

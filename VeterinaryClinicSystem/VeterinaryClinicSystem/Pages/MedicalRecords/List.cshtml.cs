using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VeterinaryClinicSystem.Pages.MedicalRecords
{
    public class ListModel : PageModel
    {
        public List<MedicalRecord> MedicalRecords { get; set; }

        public void OnGet()
        {
            MedicalRecords = MedicalRecordsDAO.GetAllMedicalRecords();
        }
    }
}

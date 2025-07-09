using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VeterinaryClinicSystem.Pages.MedicalRecords
{
    public class ListModel : PageModel
    {
        public List<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } = string.Empty;

        public void OnGet()
        {
            MedicalRecords = MedicalRecordsDAO.GetAllMedicalRecords();

            if (!string.IsNullOrEmpty(SearchString))
            {
                MedicalRecords = MedicalRecords
                    .Where(r => r.Pet != null && r.Pet.Name != null && r.Pet.Name.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }
    }

}

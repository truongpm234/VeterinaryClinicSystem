using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Service;
using System.Collections.Generic;

namespace VeterinaryClinicSystem.Pages.Staff
{
    public class MedicationsModel : PageModel
    {
        private readonly IMedicationsService _medicationsService;

        public MedicationsModel(IMedicationsService medicationsService)
        {
            _medicationsService = medicationsService;
        }

        [BindProperty]
        public Medication Medication { get; set; } = new Medication();

        public List<Medication> Medications { get; set; }

        public void OnGet()
        {
            LoadMedications();
        }

        public IActionResult OnPostAdd()
        {
            if (!ModelState.IsValid)
            {
                LoadMedications();
                return Page();
            }

            _medicationsService.AddMedication(Medication);
            Medication = new Medication(); // reset form
            ModelState.Clear();
            LoadMedications();
            return Page();
        }

        public IActionResult OnPostEdit(int id)
        {
            Medication = _medicationsService.GetMedicationById(id) ?? new Medication();
            LoadMedications();
            return Page();
        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                LoadMedications();
                return Page();
            }

            _medicationsService.UpdateMedication(Medication);
            Medication = new Medication(); // reset form
            ModelState.Clear();
            LoadMedications();
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            _medicationsService.DeleteMedication(id);
            LoadMedications();
            return Page();
        }

        private void LoadMedications()
        {
            Medications = _medicationsService.GetAllMedications();
        }
    }
}

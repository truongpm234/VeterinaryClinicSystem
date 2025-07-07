using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Service;
using System.Collections.Generic;

namespace VeterinaryClinicSystem.Pages.Staff
{
    public class InventoryModel : PageModel
    {
        private readonly IMedicationsService _medicationsService;
        private readonly IInventoryTransactionService _inventoryService;

        public InventoryModel(IMedicationsService medicationsService,
                              IInventoryTransactionService inventoryService)
        {
            _medicationsService = medicationsService;
            _inventoryService = inventoryService;
        }

        [BindProperty]
        public InventoryTransaction InventoryTransaction { get; set; } = new InventoryTransaction();

        public List<Medication> Medications { get; set; }

        public void OnGet()
        {
            LoadData();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadData();
                return Page();
            }

            InventoryTransaction.TransactionDate = DateTime.Now;
            _inventoryService.Add(InventoryTransaction);

            TempData["SuccessMessage"] = "Giao dịch đã được lưu.";
            return RedirectToPage();
        }

        private void LoadData()
        {
            Medications = _medicationsService.GetAllMedications();
        }
    }
}

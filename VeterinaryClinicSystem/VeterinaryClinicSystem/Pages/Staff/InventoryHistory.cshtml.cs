using BusinessObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace VeterinaryClinicSystem.Pages.Staff
{
    public class InventoryHistoryModel : PageModel
    {
        private readonly IInventoryTransactionService _transactionService;
        private readonly IMedicationsService _medicationsService;

        public InventoryHistoryModel(IInventoryTransactionService transactionService,
                                     IMedicationsService medicationsService)
        {
            _transactionService = transactionService;
            _medicationsService = medicationsService;
        }

        public List<InventoryTransaction> Transactions { get; set; } = new();

        public void OnGet()
        {
            LoadTransactions();
        }

        public IActionResult OnPostDelete(int id)
        {
            _transactionService.DeleteTransaction(id);

            LoadTransactions();

            return Page(); // không redirect
        }

        private void LoadTransactions()
        {
            Transactions = _transactionService.GetAll();
        }
    }
}

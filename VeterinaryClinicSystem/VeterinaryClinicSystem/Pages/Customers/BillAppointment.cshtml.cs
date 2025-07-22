using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using System.Collections.Generic;

namespace VeterinaryClinicSystem.Pages.Customers
{
    public class BillAppointmentModel : PageModel
    {
        private readonly IMedicalRecordService _recordService;

        public BillAppointmentModel(IMedicalRecordService recordService)
        {
            _recordService = recordService;
        }

        public List<(string MedicationName, decimal UnitPrice, int Amount, decimal Total)> Medications { get; set; }
        public decimal MedicationTotal { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal Total => MedicationTotal + ServicePrice;

        [BindProperty(SupportsGet = true)]
        public int AppointmentId { get; set; }

        public void OnGet()
        {
            var bill = _recordService.CalculateTotalBillForAppointment(AppointmentId);
            Medications = bill.Medications;
            MedicationTotal = bill.MedicationTotal;
            ServicePrice = bill.ServicePrice;
        }
    }
}

using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace VeterinaryClinicSystem.Pages.MedicalRecords
{
    public class CreateModel : PageModel
    {
        private readonly IMedicalRecordsService _medicalRecordsService;
        private readonly IAppointmentService _appointmentService;
        private readonly IMedicationsService _medicationsService;
        private readonly IPrescriptionDetailService _prescriptionDetailService;

        public CreateModel(
            IMedicalRecordsService medicalRecordsService,
            IAppointmentService appointmentService,
            IMedicationsService medicationsService,
            IPrescriptionDetailService prescriptionDetailService)
        {
            _medicalRecordsService = medicalRecordsService;
            _appointmentService = appointmentService;
            _medicationsService = medicationsService;
            _prescriptionDetailService = prescriptionDetailService;
        }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = new();

        [BindProperty]
        public PrescriptionDetail PrescriptionItem { get; set; } = new();

        public List<Medication> Medications { get; set; } = new();

        public string PetName { get; set; } = "";

        public IActionResult OnGet(int appointmentId)
        {
            var appointment = _appointmentService.GetAppointmentById(appointmentId);
            if (appointment == null || appointment.Status != "Đặt lịch thành công")
                return RedirectToPage("/Appointments/List");

            // Pre-fill medical record info
            MedicalRecord.AppointmentId = appointment.AppointmentId;
            MedicalRecord.PetId = appointment.PetId;
            PetName = appointment.Pet?.Name ?? "Không rõ";

            Medications = _medicationsService.GetAllMedications();
            return Page();
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("PrescriptionItem.Record");
            ModelState.Remove("PrescriptionItem.Medication");

            if (!ModelState.IsValid)
            {
                Medications = _medicationsService.GetAllMedications();
                return Page();
            }

            int? doctorId = HttpContext.Session.GetInt32("Account");
            if (doctorId == null)
                return RedirectToPage("/Authentication/Login");

            var appointment = _appointmentService.GetAppointmentById(MedicalRecord.AppointmentId ?? 0);
            if (appointment == null)
                return RedirectToPage("/Appointments/List");

            MedicalRecord.DoctorId = doctorId.Value;
            _medicalRecordsService.AddMedicalRecord(MedicalRecord);

            // Save prescription
            PrescriptionItem.RecordId = MedicalRecord.RecordId;
            _prescriptionDetailService.AddPrescriptionDetails(
                new List<PrescriptionDetail> { PrescriptionItem },
                MedicalRecord.RecordId);

            return RedirectToPage("/MedicalRecords/PetsList");
        }
    }
}

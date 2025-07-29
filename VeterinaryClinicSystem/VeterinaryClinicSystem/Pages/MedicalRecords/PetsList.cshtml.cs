using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service;

namespace VeterinaryClinicSystem.Pages.MedicalRecords
{
    public class PetsListModel : PageModel
    {
        private readonly IMedicalRecordsService _medicalRecordsService;

        public PetsListModel(IMedicalRecordsService medicalRecordsService)
        {
            _medicalRecordsService = medicalRecordsService;
        }

        public List<Pet> Pets { get; set; } = new();

        public Dictionary<int, int> PetAppointments { get; set; } = new(); // PetId -> AppointmentId

        public void OnGet()
        {
            int? doctorId = HttpContext.Session.GetInt32("Account");
            if (doctorId == null)
            {
                RedirectToPage("/Authentication/Login");
                return;
            }

            Pets = _medicalRecordsService.GetPetsWithAppointmentsTodayForDoctor(doctorId);
            PetAppointments = new();

            foreach (var pet in Pets)
            {
                var appointment = pet.Appointments.FirstOrDefault(a =>
                    a.AppointmentDate?.Date == DateTime.Today &&
                    a.Status == "Đặt lịch thành công");

                if (appointment != null)
                {
                    PetAppointments[pet.PetId] = appointment.AppointmentId;
                }
            }
        }
    }

}

using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DoctorDashboardDAO
    {
        private readonly VeterinaryClinicSystemContext _context;

        public DoctorDashboardDAO(VeterinaryClinicSystemContext context)
        {
            _context = context;
        }
        public static List<DoctorDashboard> GetTodayAppointments(int doctorId)
        {
            using var context = new VeterinaryClinicSystemContext();
            var today = DateTime.Today;

            return context.Appointments
                .Where(a => a.DoctorId == doctorId && a.AppointmentDate.HasValue && a.AppointmentDate.Value.Date == today)
                .Select(a => new DoctorDashboard
                {
                    AppointmentId = a.AppointmentId,
                    PatientName = a.Owner != null ? a.Owner.FullName : "N/A",
                    AppointmentDate = a.AppointmentDate.Value, // Explicitly cast to DateTime
                    AppointmentTime = a.AppointmentDate.HasValue ? a.AppointmentDate.Value.TimeOfDay : TimeSpan.Zero,
                    Reason = a.Note ?? "Không có ghi chú"
                }).ToList();
        }





        public static List<DoctorDashboard> GetOngoingCases(int doctorId)
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.MedicalRecords
                //.Where(m => m.DoctorId == doctorId && m.IsCompleted != true)
                .Select(m => new DoctorDashboard
                {
                    MedicalRecordId = m.RecordId,
                    PatientName = m.Pet != null ? m.Pet.Name : // Fixed: Use 'Name' instead of 'PetName'
                                   m.Appointment != null && m.Appointment.Owner != null
                                       ? m.Appointment.Owner.FullName
                                       : "Không rõ",
                    Diagnosis = m.Diagnosis ?? "Chưa chẩn đoán",
                    IsOngoingCase = true
                }).ToList();
        }

    }
}
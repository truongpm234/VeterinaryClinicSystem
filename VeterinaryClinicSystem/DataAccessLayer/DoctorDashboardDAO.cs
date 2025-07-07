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
        public List<DoctorDashboardItem> GetTodayAppointments(int doctorId)
        {
            var today = DateTime.Today;

            return _context.Appointments
                .Include(a => a.Owner) // ✅ Load navigation property
                .Where(a => a.DoctorId == doctorId
                            && a.AppointmentDate.HasValue
                            && a.AppointmentDate.Value.Date == today) // ✅ Check nullable
                .Select(a => new DoctorDashboardItem
                {
                    AppointmentId = a.AppointmentId,
                    PatientName = a.Owner != null ? a.Owner.FullName : "Không xác định",
                    AppointmentDate = a.AppointmentDate ?? DateTime.MinValue,
                    AppointmentTime = a.AppointmentDate.HasValue
                        ? a.AppointmentDate.Value.TimeOfDay
                        : TimeSpan.Zero,
                    Reason = a.Note // dùng Note thay cho Reason
                }).ToList();
        }




        public List<DoctorDashboardItem> GetOngoingCases(int doctorId)
        {
            return _context.MedicalRecords
                .Include(m => m.Pet)
                .Where(m => m.DoctorId == doctorId && !m.IsCompleted.GetValueOrDefault())
                .Select(m => new DoctorDashboardItem
                {
                    MedicalRecordId = m.RecordId,
                    //PatientName = m..FullName,
                    Diagnosis = m.Diagnosis,
                    IsOngoingCase = true
                }).ToList();
        }
    }
}

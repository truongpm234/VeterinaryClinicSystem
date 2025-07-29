using BusinessObject;
using BusinessObject.Models;
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
                .Where(a => a.DoctorId == doctorId
                    && a.AppointmentDate.HasValue
                    && a.AppointmentDate.Value.Date == today
                    && a.Status == "Đặt lịch thành công")
                .Select(a => new DoctorDashboard
                {
                    AppointmentId = a.AppointmentId,
                    PatientName = a.Owner != null ? a.Owner.FullName : "N/A",
                    AppointmentDate = a.AppointmentDate.Value,
                    AppointmentTime = a.AppointmentDate.Value.TimeOfDay,
                    Shift = a.Shift,
                    ServiceName = a.Service != null ? a.Service.Name : "Không rõ",
                    Reason = a.Note ?? "Không có ghi chú"
                }).ToList();
        }

        public static List<DoctorDashboard> GetOngoingCases(int doctorId)
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.MedicalRecords
                .Where(m => m.DoctorId == doctorId)
                .Select(m => new DoctorDashboard
                {
                    MedicalRecordId = m.RecordId,
                    PatientName = m.Pet != null ? m.Pet.Name : m.Appointment != null && m.Appointment.Owner != null ? m.Appointment.Owner.FullName : "Không rõ",
                    Diagnosis = m.Diagnosis ?? "Chưa chẩn đoán",
                    IsOngoingCase = true
                }).ToList();
        }

        public static List<DoctorWorkScheduleItem> GetMonthlySchedule(int doctorId)
        {
            using var context = new VeterinaryClinicSystemContext();

            var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            return context.Appointments
                .Where(a => a.DoctorId == doctorId
                            && a.AppointmentDate.HasValue
                            && a.AppointmentDate.Value.Date >= startOfMonth
                            && a.AppointmentDate.Value.Date <= endOfMonth
                            && a.Status == "Đặt lịch thành công")
                .Select(a => new DoctorWorkScheduleItem
                {
                    AppointmentId = a.AppointmentId,
                    AppointmentDate = a.AppointmentDate.Value,
                    ServiceName = a.Service != null ? a.Service.Name : "Không rõ",
                    Shift = a.Shift ?? 0,
                    Note = a.Note ?? "Không có ghi chú"
                }).OrderBy(a => a.AppointmentDate)
                  .ThenBy(a => a.Shift)
                  .ToList();
        }

    }
}
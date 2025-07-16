using BusinessObject;
using DataAccessLayer;

namespace Service
{
    public class DashboardService : IDashboardService
    {
        private readonly VeterinaryClinicSystemContext _context;

        public DashboardService(VeterinaryClinicSystemContext context)
        {
            _context = context;
        }

        public DashboardStats GetDashboardStats()
        {
            var today = DateTime.Today;
            var now = DateTime.Now;

            var totalAppointmentsToday = _context.Appointments
                .Count(a => a.AppointmentDate.HasValue && a.AppointmentDate.Value.Date == today);

            var totalAppointmentsThisMonth = _context.Appointments
                .Count(a => a.CreatedAt.HasValue &&
                            a.CreatedAt.Value.Month == now.Month &&
                            a.CreatedAt.Value.Year == now.Year);

            var revenueToday = _context.Appointments
                .Where(a => a.AppointmentDate.HasValue && a.AppointmentDate.Value.Date == today)
                .Join(_context.Services,
                    appointment => appointment.ServiceId,
                    service => service.ServiceId,
                    (appointment, service) => service.Price ?? 0)
                .Sum();

            var revenueThisMonth = _context.Appointments
                .Where(a => a.CreatedAt.HasValue &&
                            a.CreatedAt.Value.Month == now.Month &&
                            a.CreatedAt.Value.Year == now.Year)
                .Join(_context.Services,
                    appointment => appointment.ServiceId,
                    service => service.ServiceId,
                    (appointment, service) => service.Price ?? 0)
                .Sum();

            return new DashboardStats
            {
                TotalAppointmentsToday = totalAppointmentsToday,
                TotalAppointmentsThisMonth = totalAppointmentsThisMonth,
                RevenueToday = revenueToday,
                RevenueThisMonth = revenueThisMonth
            };
        }


        public List<DoctorDashboard> GetTodayAppointments(int doctorId)
        {
            // Initialize an empty list to ensure all code paths return a value
            var appointments = new List<DoctorDashboard>();

            // Add logic here to populate appointments from _context if needed
            // Example:
            // appointments = _context.Appointments
            //     .Where(a => a.DoctorId == doctorId && a.AppointmentDate.Date == DateTime.Today)
            //     .Select(a => new DoctorDashboardItem
            //     {
            //         AppointmentId = a.Id,
            //         PatientName = a.Patient.Name,
            //         AppointmentDate = a.AppointmentDate,
            //         AppointmentTime = a.AppointmentTime,
            //         Reason = a.Reason,
            //         MedicalRecordId = a.MedicalRecordId,
            //         Diagnosis = a.Diagnosis,
            //         IsOngoingCase = a.IsOngoingCase
            //     }).ToList();

            return appointments; // Ensure a value is always returned
        }

        public List<DoctorDashboard> GetOngoingCases(int doctorId)
        {
            var ongoingCases = new List<DoctorDashboard>();
            // your implementation here
            return ongoingCases;
        }
    }
}

using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataAccessLayer
{
    public class DashboardDAO
    {
        private readonly VeterinaryClinicSystemContext _context;

        public DashboardDAO(VeterinaryClinicSystemContext context)
        {
            _context = context;
        }

        public static DashboardStats GetDashboardStats()
        {
            using var _context = new VeterinaryClinicSystemContext(); // Ensure you have the correct context instance
            var today = DateTime.Today;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

            var stats = new DashboardStats
            {
                TotalAppointmentsToday = _context.Appointments
                    .Count(a => a.AppointmentDate.HasValue && a.AppointmentDate.Value.Date == today),

                TotalAppointmentsThisMonth = _context.Appointments
                    .Count(a => a.AppointmentDate.HasValue
                     && a.AppointmentDate.Value.Month == today.Month
                        && a.AppointmentDate.Value.Year == today.Year),


                RevenueToday = _context.Appointments
                    .Where(a => a.AppointmentDate.HasValue && a.AppointmentDate.Value.Date == today)
                    .Sum(a => a.Service != null ? (a.Service.Price ?? 0) : 0),

                RevenueThisMonth = _context.Appointments
                    .Where(a => a.AppointmentDate.HasValue && a.AppointmentDate.Value >= firstDayOfMonth)
                    .Sum(a => a.Service != null ? (a.Service.Price ?? 0) : 0)
            };

            return stats;
        }

       


        public static List<DoctorDashboard> GetTodayAppointments(int doctorId)
        {

            
            var appointments = new List<DoctorDashboard>();

         

            return appointments; 
        }

        public static List<DoctorDashboard> GetOngoingCases(int doctorId)
        {
            var ongoingCases = new List<DoctorDashboard>();
            // your implementation here
            return ongoingCases;
        }
    }
}
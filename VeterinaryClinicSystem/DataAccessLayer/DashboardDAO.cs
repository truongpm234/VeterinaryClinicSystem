using BusinessObject.Models;
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

        public DashboardStats GetDashboardStats()
        {
            var today = DateTime.Today;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

            var stats = new DashboardStats
            {
                TotalAppointmentsToday = _context.Appointments
                    .Count(a => a.AppointmentDate.HasValue && a.AppointmentDate.Value.Date == today),

                TotalAppointmentsThisMonth = _context.Appointments
                    .Count(a => a.AppointmentDate.HasValue && a.AppointmentDate.Value >= firstDayOfMonth),

                RevenueToday = _context.Appointments
                    .Where(a => a.AppointmentDate.HasValue && a.AppointmentDate.Value.Date == today)
                    .Sum(a => a.Service != null ? (a.Service.Price ?? 0) : 0),

                RevenueThisMonth = _context.Appointments
                    .Where(a => a.AppointmentDate.HasValue && a.AppointmentDate.Value >= firstDayOfMonth)
                    .Sum(a => a.Service != null ? (a.Service.Price ?? 0) : 0)
            };

            return stats;
        }
    }
}

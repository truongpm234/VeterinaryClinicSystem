using BusinessObject;
using BusinessObject.Models;
using DataAccessLayer;

namespace Service
{
    public interface IDoctorDashboardService
    {
        List<DoctorDashboard> GetTodayAppointments(int doctorId);
        List<DoctorDashboard> GetOngoingCases(int doctorId);
        public List<DoctorWorkScheduleItem> GetMonthlySchedule(int doctorId);
    }
}
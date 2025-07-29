using BusinessObject;
using BusinessObject.Models;
using DataAccessLayer;

namespace Repository
{
    public interface IDoctorDashboardRepository
    {
        List<DoctorDashboard> GetTodayAppointments(int doctorId);
        List<DoctorDashboard> GetOngoingCases(int doctorId);
        public List<DoctorWorkScheduleItem> GetMonthlySchedule(int doctorId);
        
    }
}
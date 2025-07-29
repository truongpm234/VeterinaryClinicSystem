using BusinessObject;
using BusinessObject.Models;
using DataAccessLayer;
using Repository;

namespace Service
{
    public class DoctorDashboardService : IDoctorDashboardService
    {
        private readonly IDoctorDashboardRepository _doctorDashboardRepository;

        public DoctorDashboardService(IDoctorDashboardRepository dao)
        {
            _doctorDashboardRepository = dao;
        }

        public List<DoctorDashboard> GetTodayAppointments(int doctorId)
        {
            return _doctorDashboardRepository.GetTodayAppointments(doctorId);
        }

        public List<DoctorDashboard> GetOngoingCases(int doctorId)
        {
            return _doctorDashboardRepository.GetOngoingCases(doctorId);
        }
        public List<DoctorWorkScheduleItem> GetMonthlySchedule(int doctorId)
        {
            return _doctorDashboardRepository.GetMonthlySchedule(doctorId);
        }
    }
}
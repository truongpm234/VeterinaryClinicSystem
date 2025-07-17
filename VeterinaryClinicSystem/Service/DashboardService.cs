using BusinessObject;
using DataAccessLayer;
using Repository;

namespace Service
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _doctorDashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _doctorDashboardRepository = dashboardRepository;

        }
        public DashboardStats GetDashboardStats() => _doctorDashboardRepository.GetDashboardStats();
        public List<DoctorDashboard> GetOngoingCases(int doctorId) => _doctorDashboardRepository.GetOngoingCases(doctorId);
        public List<DoctorDashboard> GetTodayAppointments(int doctorId) => _doctorDashboardRepository.GetTodayAppointments(doctorId);
    }
}
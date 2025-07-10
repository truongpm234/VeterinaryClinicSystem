using BusinessObject;
using DataAccessLayer;

namespace Service
{
    public class DoctorDashboardService
    {
        private readonly DoctorDashboardDAO _dao;

        public DoctorDashboardService(DoctorDashboardDAO dao)
        {
            _dao = dao;
        }

        public List<DoctorDashboardItem> GetTodayAppointments(int doctorId)
        {
            return _dao.GetTodayAppointments(doctorId);
        }

        public List<DoctorDashboardItem> GetOngoingCases(int doctorId)
        {
            return _dao.GetOngoingCases(doctorId);
        }
    }
}

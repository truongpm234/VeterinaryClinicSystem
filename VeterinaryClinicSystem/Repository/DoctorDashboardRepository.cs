using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DoctorDashboardRepository : IDoctorDashboardRepository
    {
        private readonly DoctorDashboardDAO _dao;

        public DoctorDashboardRepository(DoctorDashboardDAO dao)
        {
            _dao = dao;
        }

        public List<DoctorDashboard> GetTodayAppointments(int doctorId)
        {
            return DoctorDashboardDAO.GetTodayAppointments(doctorId);
        }

        public List<DoctorDashboard> GetOngoingCases(int doctorId)
        {
            return DoctorDashboardDAO.GetOngoingCases(doctorId);
        }
    }

}

using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        public DashboardStats GetDashboardStats() => DashboardDAO.GetDashboardStats();
        public List<DoctorDashboard> GetOngoingCases(int doctorId) => DashboardDAO.GetOngoingCases(doctorId);    
        public List<DoctorDashboard> GetTodayAppointments(int doctorId) => DashboardDAO.GetTodayAppointments(doctorId);
    }
}

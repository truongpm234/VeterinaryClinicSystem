using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDashboardRepository
    {
        public DashboardStats GetDashboardStats();
        public List<DoctorDashboard> GetOngoingCases(int doctorId);
        public List<DoctorDashboard> GetTodayAppointments(int doctorId);

    }
}

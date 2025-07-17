using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDashboardService
    {
        DashboardStats GetDashboardStats();
        List<DoctorDashboard> GetTodayAppointments(int doctorId);
        List<DoctorDashboard> GetOngoingCases(int doctorId);
    }
}

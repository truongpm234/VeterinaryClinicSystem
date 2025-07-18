using BusinessObject.Models;
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
        List<DoctorDashboardItem> GetTodayAppointments(int doctorId);
        List<DoctorDashboardItem> GetOngoingCases(int doctorId);
    }
}


using BusinessObject;

namespace Service
{
    public interface IDoctorDashboardService
    {
        List<DoctorDashboard> GetTodayAppointments(int doctorId);
        List<DoctorDashboard> GetOngoingCases(int doctorId);
    }
}
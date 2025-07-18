using BusinessObject;

namespace Repository
{
    public interface IDoctorDashboardRepository
    {
        List<DoctorDashboard> GetTodayAppointments(int doctorId);
        List<DoctorDashboard> GetOngoingCases(int doctorId);
    }
}
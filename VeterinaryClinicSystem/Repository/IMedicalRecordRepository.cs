using BusinessObject.Models;

namespace Repository
{
    public interface IMedicalRecordRepository
    {
        BillDetail CalculateTotalBillForAppointment(int appointmentId);
    }
}
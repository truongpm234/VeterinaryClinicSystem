namespace BusinessObject.Models;

public class DoctorDashboardItem
{
    public int AppointmentId { get; set; }
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public string Reason { get; set; }

    // Ca bệnh đang theo dõi
    public int MedicalRecordId { get; set; }
    public string Diagnosis { get; set; }
    public bool IsOngoingCase { get; set; }
}
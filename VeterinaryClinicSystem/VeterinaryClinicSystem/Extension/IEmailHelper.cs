using BusinessObject;
using DataAccessLayer;

namespace VeterinaryClinicSystem.Extension
{
    public interface IEmailHelper
    {
        Task<bool> SendEmailAsync(string toEmail, string subject, string htmlBody);
        Task<bool> EmailForCreateAppointment(Appointment appointment, VeterinaryClinicSystemContext context);
        Task<bool> EmailForAcceptAppointment(Appointment appointment, DoctorSchedule schedule, VeterinaryClinicSystemContext context);
        Task<bool> EmailForRejectAppointment(Appointment appointment, DoctorSchedule schedule, VeterinaryClinicSystemContext context);
        Task<bool> EmailForLateAppointmentAsync(Appointment appointment, VeterinaryClinicSystemContext context);
        Task<bool> EmailForCareScheduleAsync(Pet pet, CareSchedule schedule, string customerEmail);




    }
}

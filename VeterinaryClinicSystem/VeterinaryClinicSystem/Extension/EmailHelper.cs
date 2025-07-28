using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinicSystem;

namespace VeterinaryClinicSystem.Extension
{


    public class EmailHelper : IEmailHelper
    {
        private readonly SmtpSettings _smtp;
        private readonly ILogger<EmailHelper> _logger;

        public EmailHelper(IOptions<SmtpSettings> smtpOptions, ILogger<EmailHelper> logger)
        {
            _smtp = smtpOptions.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string htmlBody)
        {
            if (string.IsNullOrWhiteSpace(toEmail))
            {
                _logger.LogError("Email address is null or empty.");
                return false;
            }

            try
            {
                using var mail = new MailMessage
                {
                    From = new MailAddress(_smtp.User, "VeterinaryClinic.com.vn"),
                    Subject = subject,
                    Body = htmlBody,
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(toEmail));

                using var client = new SmtpClient(_smtp.Host, _smtp.Port)
                {
                    Credentials = new NetworkCredential(_smtp.User, _smtp.Pass),
                    EnableSsl = _smtp.EnableSsl
                };

                await client.SendMailAsync(mail);
                _logger.LogInformation($"Email sent to {toEmail}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {Email}", toEmail);
                return false;
            }
        }

        public async Task<bool> EmailForCreateAppointment(Appointment appointment, VeterinaryClinicSystemContext context)
        {
            try
            {
                var owner = await context.Users.FindAsync(appointment.OwnerId);

                if (string.IsNullOrWhiteSpace(owner?.Email))
                {
                    _logger.LogWarning($"❌ Không thể gửi email vì tài khoản {owner.UserId} không có địa chỉ email.", owner?.UserId);
                    return false;
                }

                var doctor = await context.Users.FindAsync(appointment.DoctorId);
                var service = await context.Services.FindAsync(appointment.ServiceId);
                var pet = await context.Pets.FindAsync(appointment.PetId);

                string shiftDescription = appointment.Shift switch
                {
                    1 => "Ca 1: Sáng (7:00 - 8:30)",
                    2 => "Ca 2: Sáng (8:30 - 10:00)",
                    3 => "Ca 3: Sáng (10:00 - 11:30)",
                    4 => "Ca 4: Chiều (13:30 - 15:00)",
                    5 => "Ca 5: Chiều (15:00 - 16:30)",
                    _ => $"Ca {appointment.Shift}: Không xác định"
                };

                string htmlBody = $@"
<div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; border: 1px solid #e0e0e0; border-radius: 8px;'>
    <h2 style='color: #2c3e50;'>📅 Yêu cầu đặt lịch hẹn đã được ghi nhận</h2>
    <p>Chào <strong>{owner.FullName}</strong>,</p>
    <p>Bạn đã yêu cầu <strong>đặt lịch khám</strong> với các thông tin sau:</p>

    <table style='width: 100%; border-collapse: collapse;'>
        <tr><td style='padding: 8px; font-weight: bold;'>👨‍⚕️ Bác sĩ:</td><td style='padding: 8px;'>{doctor?.FullName}</td></tr>
        <tr><td style='padding: 8px; font-weight: bold;'>🦴 Dịch vụ:</td><td style='padding: 8px;'>{service?.Name}</td></tr>
        <tr><td style='padding: 8px; font-weight: bold;'>🐾 Tên thú cưng:</td><td style='padding: 8px;'>{pet?.Name}</td></tr>
        <tr><td style='padding: 8px; font-weight: bold;'>📅 Ngày hẹn:</td><td style='padding: 8px;'>{appointment.AppointmentDate:dd/MM/yyyy}</td></tr>
        <tr><td style='padding: 8px; font-weight: bold;'>⏰ Ca khám:</td><td style='padding: 8px;'>{shiftDescription}</td></tr>
    </table>

    <p style='margin-top: 20px;'>⏳ Lịch hẹn của bạn đang được kiểm tra xem có bị trùng với lịch bác sĩ hay không. Chúng tôi sẽ gửi email xác nhận hoặc từ chối trong thời gian sớm nhất.</p>
    <p style='color: #888;'>--<br>VeterinaryClinic.com.vn</p>
</div>";

                return await SendEmailAsync(owner.Email, "📩 Xác nhận yêu cầu đặt lịch", htmlBody);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Lỗi khi gửi email xác nhận lịch hẹn.");
                return false;
            }
        }

        public async Task<bool> EmailForAcceptAppointment(Appointment appointment, DoctorSchedule schedule, VeterinaryClinicSystemContext context)
        {
            try
            {
                var owner = await context.Users.FindAsync(appointment.OwnerId);

                if (string.IsNullOrWhiteSpace(owner?.Email))
                {
                    _logger.LogWarning($"❌ Không thể gửi email vì tài khoản {owner?.UserId} không có địa chỉ email.");
                    return false;
                }

                var doctor = await context.Users.FindAsync(appointment.DoctorId);
                var service = await context.Services.FindAsync(appointment.ServiceId);
                var pet = await context.Pets.FindAsync(appointment.PetId);

                string shiftDescription = schedule.Shift switch
                {
                    1 => "Ca 1: Sáng (7:00 - 8:30)",
                    2 => "Ca 2: Sáng (8:30 - 10:00)",
                    3 => "Ca 3: Sáng (10:00 - 11:30)",
                    4 => "Ca 4: Chiều (13:30 - 15:00)",
                    5 => "Ca 5: Chiều (15:00 - 16:30)",
                    _ => $"Ca {schedule.Shift}: Không xác định"
                };

                string htmlBody = $@"
        <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; border: 1px solid #e0e0e0; border-radius: 8px;'>
            <h2 style='color: #2c3e50;'>Xác nhận lịch hẹn từ VeterinaryClinic.com.vn</h2>
            <p>Chào <strong>{owner.FullName}</strong>,</p>
            <p>Bạn đã <strong>đặt lịch khám</strong> với thông tin sau:</p>

            <table style='width: 100%; border-collapse: collapse;'>
                <tr>
                    <td style='padding: 8px; font-weight: bold;'>👨‍⚕️ Bác sĩ:</td>
                    <td style='padding: 8px;'>{doctor?.FullName}</td>
                </tr>
                <tr>
                    <td style='padding: 8px; font-weight: bold;'>🦴 Dịch vụ:</td>
                    <td style='padding: 8px;'>{service?.Name}</td>
                </tr>
                <tr>
                    <td style='padding: 8px; font-weight: bold;'>🐾 Tên thú cưng:</td>
                    <td style='padding: 8px;'>{pet?.Name}</td>
                </tr>
                <tr>
                    <td style='padding: 8px; font-weight: bold;'>📅 Ngày hẹn:</td>
                    <td style='padding: 8px;'>{appointment.AppointmentDate:dd/MM/yyyy}</td>
                </tr>
                <tr>
                    <td style='padding: 8px; font-weight: bold;'>⏰ Ca khám:</td>
                    <td style='padding: 8px;'>{shiftDescription}</td>
                </tr>
            </table>

            <p style='margin-top: 20px;'>💡 Vui lòng đến đúng giờ để không ảnh hưởng đến các lịch hẹn khác. Cám ơn bạn đã tin tưởng sử dụng dịch vụ của chúng tôi!</p>

            <p style='color: #888;'>--<br>VeterinaryClinic.com.vn</p>
        </div>";

                return await SendEmailAsync(owner.Email, "✅ Lịch hẹn đã được xác nhận", htmlBody);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Lỗi khi gửi email xác nhận lịch hẹn.");
                return false;
            }
        }

        public async Task<bool> EmailForRejectAppointment(Appointment appointment, DoctorSchedule schedule, VeterinaryClinicSystemContext context)
        {
            try
            {
                var owner = await context.Users.FindAsync(appointment.OwnerId);

                if (string.IsNullOrWhiteSpace(owner?.Email))
                {
                    _logger.LogWarning($"❌ Không thể gửi email vì tài khoản {owner.UserId} không có địa chỉ email.", owner?.UserId);
                    return false;
                }

                var doctor = await context.Users.FindAsync(appointment.DoctorId);
                var service = await context.Services.FindAsync(appointment.ServiceId);
                var pet = await context.Pets.FindAsync(appointment.PetId);
                var doctorSchedule = await context.DoctorSchedules.FindAsync(schedule.ScheduleId);
                string shiftDescription = schedule.Shift switch
                {
                    1 => "Sáng (7:00 - 8:30)",
                    2 => "Sáng (8:30 - 10:00)",
                    3 => "Sáng (10:00 - 11:30)",
                    4 => "Chiều (13:30 - 15:00)",
                    5 => "Chiều (15:00 - 16:30)",
                    _ => "Không xác định"
                };

                string htmlBody = $@"
<div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; border: 1px solid #e0e0e0; border-radius: 8px;'>
    <h2 style='color: #e74c3c;'>❌ Lịch hẹn bị từ chối</h2>
    <p>Chào <strong>{owner.FullName}</strong>,</p>
    <p>Lịch hẹn của bạn với bác sĩ <strong>{doctor?.FullName}</strong> đã bị từ chối do trùng lịch.</p>

    <table style='width: 100%; border-collapse: collapse;'>
        <tr><td style='padding: 8px; font-weight: bold;'>🦴 Dịch vụ:</td><td style='padding: 8px;'>{service?.Name}</td></tr>
        <tr><td style='padding: 8px; font-weight: bold;'>🐾 Tên thú cưng:</td><td style='padding: 8px;'>{pet?.Name}</td></tr>
        <tr><td style='padding: 8px; font-weight: bold;'>📅 Ngày hẹn:</td><td style='padding: 8px;'>{appointment.AppointmentDate:dd/MM/yyyy}</td></tr>
        <tr><td style='padding: 8px; font-weight: bold;'>⏰ Ca khám:</td><td style='padding: 8px;'>{shiftDescription}</td></tr>
    </table>

    <p style='margin-top: 20px; color: red;'>⚠️ Vui lòng chọn khung giờ khác để đặt lại lịch hẹn. Xin lỗi vì sự bất tiện này.</p>
    <p style='color: #888;'>--<br>VeterinaryClinic.com.vn</p>
</div>";

                return await SendEmailAsync(owner.Email, "Xác nhận lịch hẹn", htmlBody);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Lỗi khi gửi email xác nhận lịch hẹn.");
                return false;
            }
        }

        public async Task<bool> EmailForLateAppointmentAsync(Appointment appointment, VeterinaryClinicSystemContext context)
        {
            try
            {
                var owner = await context.Users.FindAsync(appointment.OwnerId);

                if (string.IsNullOrWhiteSpace(owner?.Email))
                {
                    _logger.LogWarning($"❌ Không thể gửi email vì tài khoản {owner?.UserId} không có địa chỉ email.");
                    return false;
                }

                var doctor = await context.Users.FindAsync(appointment.DoctorId);
                var service = await context.Services.FindAsync(appointment.ServiceId);
                var pet = await context.Pets.FindAsync(appointment.PetId);

                string shiftDescription = appointment.Shift switch
                {
                    1 => "Sáng (7:00 - 8:30)",
                    2 => "Sáng (8:30 - 10:00)",
                    3 => "Sáng (10:00 - 11:30)",
                    4 => "Chiều (13:30 - 15:00)",
                    5 => "Chiều (15:00 - 16:30)",
                    _ => "Không xác định"
                };

                string htmlBody = $@"
<div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; border: 1px solid #e0e0e0; border-radius: 8px;'>
    <h2 style='color: #e67e22;'>⏰ Lịch hẹn đã quá giờ</h2>
    <p>Chào <strong>{owner.FullName}</strong>,</p>
    <p>Lịch hẹn sau đã quá thời gian và không thể thực hiện được:</p>

    <table style='width: 100%; border-collapse: collapse;'>
        <tr><td style='padding: 8px; font-weight: bold;'>👨‍⚕️ Bác sĩ:</td><td style='padding: 8px;'>{doctor?.FullName}</td></tr>
        <tr><td style='padding: 8px; font-weight: bold;'>🦴 Dịch vụ:</td><td style='padding: 8px;'>{service?.Name}</td></tr>
        <tr><td style='padding: 8px; font-weight: bold;'>🐾 Tên thú cưng:</td><td style='padding: 8px;'>{pet?.Name}</td></tr>
        <tr><td style='padding: 8px; font-weight: bold;'>📅 Ngày hẹn:</td><td style='padding: 8px;'>{appointment.AppointmentDate:dd/MM/yyyy}</td></tr>
        <tr><td style='padding: 8px; font-weight: bold;'>⏰ Ca khám:</td><td style='padding: 8px;'>{shiftDescription}</td></tr>
    </table>

    <p style='margin-top: 20px; color: red;'>⚠️ Vui lòng đặt lại lịch hẹn với thời gian phù hợp hơn.</p>
    <p style='color: #888;'>--<br>VeterinaryClinic.com.vn</p>
</div>";

                return await SendEmailAsync(owner.Email, "Thông báo lịch hẹn trễ", htmlBody);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Lỗi khi gửi email trễ giờ hẹn.");
                return false;
            }
        }

        public async Task<bool> EmailForCareScheduleAsync(Pet pet, CareSchedule schedule, string customerEmail)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerEmail))
                {
                    _logger.LogWarning("❌ Không có email khách hàng.");
                    return false;
                }

                string htmlBody = $@"
<div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; border: 1px solid #e0e0e0; border-radius: 8px; background-color: #fdfdfd;'>
    <h2 style='color: #2c3e50;'>📢 Nhắc lịch tiêm phòng cho thú cưng <strong style='color: #27ae60'>{pet.Name}</strong></h2>

    <p><strong>🔹 Loại chăm sóc:</strong> {schedule.CareType}</p>
    <p><strong>📅 Ngày tiêm lần đầu:</strong> {schedule.InitialDate:dd/MM/yyyy}</p>
    <p style='font-size: 1.2em; color: #c0392b;'><strong>📌 Ngày tiêm nhắc lại (quan trọng):</strong> {schedule.NextDueDate:dd/MM/yyyy}</p>

    <hr style='margin: 20px 0;' />

    <p style='color: #555;'>💡 Vui lòng đưa thú cưng đến tiêm đúng lịch để đảm bảo sức khỏe và hiệu quả tiêm phòng.</p>
    <p style='color: #999; font-size: 0.9em;'>Nếu bỏ lỡ lịch tiêm, vui lòng liên hệ lại với phòng khám để được tư vấn thêm.</p>

    <br />
    <p style='font-style: italic;'>--<br>VeterinaryClinic.com.vn</p>
</div>";

                return await SendEmailAsync(customerEmail, $"📅 Lịch nhắc tiêm phòng cho {pet.Name}", htmlBody);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"❌ Lỗi gửi email lịch tiêm phòng đến {customerEmail}");
                return false;
            }
        }
    }
}
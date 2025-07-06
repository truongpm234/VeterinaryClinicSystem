using BusinessObject;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinicSystem.Repositories;

namespace Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _repo;
        private readonly IEmailHelper _email;
        public AppointmentService(IAppointmentRepository repo, IEmailHelper email)
            => (_repo, _email) = (repo, email);

        // Lấy danh sách
        public async Task<List<Appointment>> GetAllAsync()
            => await _repo.GetAllAsync();

        // Tạo mới + thông báo
        public async Task<Appointment> CreateAndNotifyAsync(Appointment appt)
        {
            // 1. Lưu lịch hẹn
            appt.CreatedAt = DateTime.Now;
            var saved = await _repo.AddAsync(appt);

            // 2. Lấy dữ liệu Owner và Doctor đã lưu
            var owner = await _repo.GetOwnerByIdAsync(saved.OwnerId.Value);
            Doctor doctor = null;
            if (saved.DoctorId.HasValue)
                doctor = await _repo.GetDoctorByIdAsync(saved.DoctorId.Value);

            // 3. Soạn email
            var subject = $"[VetClinic] Xác nhận lịch hẹn #{saved.AppointmentId}";
            var doctorInfo = doctor != null
                ? $"bác sĩ #{doctor.DoctorId}"
                : "bác sĩ";
            // chỉ format đến phút, không có giây
            var when = saved.AppointmentDate.Value.ToString("dd/MM/yyyy HH:mm");
            var body = $@"
                <p>Chào {owner.FullName},</p>
                <p>Bạn đã đặt lịch thành công vào {when} với {doctorInfo}.</p>
                <p>Trân trọng!</p>";

            // 4. Gửi email dùng thông tin vừa fetch
            await _email.SendEmailAsync(owner.Email, subject, body);

            return saved;
        }
    }
}

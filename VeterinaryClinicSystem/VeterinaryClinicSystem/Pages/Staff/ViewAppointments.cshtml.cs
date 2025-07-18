using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Service;
using SignalRLab;
using VeterinaryClinicSystem.Extension;

namespace VeterinaryClinicSystem.Pages.Staff
{
    public class ViewAppointmentsModel : PageModel
    {
        private readonly IAppointmentService _appointment;
        private readonly IEmailHelper _emailHelper;
        private readonly VeterinaryClinicSystemContext _context;
        private readonly IHubContext<AppointmentHub> _hubContext;

        public ViewAppointmentsModel(IAppointmentService appointment, IEmailHelper emailHelper, VeterinaryClinicSystemContext context, IHubContext<AppointmentHub> hubContext)
        {
            _appointment = appointment;
            _emailHelper = emailHelper;
            _context = context;
            _hubContext = hubContext;
        }

        public List<Appointment> AppointmentsList { get; set; } = new();
        public List<(DoctorSchedule Schedule, string DoctorName)> SchedulesWithDoctorName { get; set; } = new();

        public async Task OnGetAsync()
        {
            AppointmentsList = await _appointment.GetAllAppointmentsAsync();
            SchedulesWithDoctorName = await _appointment.GetDoctorSchedulesWithNamesAsync();
            await UpdateScheduleStatusAsync();
        }

        public async Task<IActionResult> OnPostAcceptAsync(int appointmentId)
        {
            var appointment = AppointmentsList.FirstOrDefault(a => a.AppointmentId == appointmentId)
                              ?? await _appointment.GetAppointmentByIdAsync(appointmentId);

            if (appointment == null || appointment.AppointmentDate == null || appointment.Shift == null || appointment.DoctorId == null)
            {
                TempData["Error"] = "❌ Dữ liệu lịch hẹn không hợp lệ.";
                return RedirectToPage();
            }

            var workDate = DateOnly.FromDateTime(appointment.AppointmentDate.Value);

            var success = await _appointment.AcceptAppointmentAsync(appointmentId);

            var acceptedSchedule = new DoctorSchedule
            {
                DoctorId = appointment.DoctorId,
                WorkDate = workDate,
                Shift = appointment.Shift,
                Note = appointment.Note
            };

            await _hubContext.Clients.All.SendAsync("ReceiveAppointmentUpdate", $"Lịch hẹn {appointmentId} đã được cập nhật.");

            await _emailHelper.EmailForAcceptAppointment(appointment, acceptedSchedule, _context);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRejectAsync(int appointmentId)
        {
            var appointment = AppointmentsList.FirstOrDefault(a => a.AppointmentId == appointmentId)
                              ?? await _appointment.GetAppointmentByIdAsync(appointmentId);

            if (appointment == null || appointment.AppointmentDate == null || appointment.Shift == null)
            {
                TempData["Error"] = "❌ Không tìm thấy lịch hẹn hoặc thông tin không hợp lệ.";
                return RedirectToPage();
            }

            var schedule = new DoctorSchedule
            {
                DoctorId = appointment.DoctorId,
                WorkDate = DateOnly.FromDateTime(appointment.AppointmentDate.Value),
                Shift = appointment.Shift,
                Note = appointment.Note
            };
            var endTime = GetShiftEndTime(schedule.WorkDate.Value, schedule.Shift.Value);
            var now = DateTime.Now;

            if (now > endTime)
            {
                appointment.Status = "Từ chối hẹn";
                _context.Appointments.Update(appointment);
                await _context.SaveChangesAsync();

                await _emailHelper.EmailForLateAppointmentAsync(appointment, _context);
                TempData["Message"] = "⏰ Đã từ chối lịch hẹn vì đã quá giờ.";

                return RedirectToPage();
            }

            // Nếu chưa quá giờ thì từ chối bình thường
            await _appointment.RejectAppointmentAsync(appointmentId);

            await _hubContext.Clients.All.SendAsync("ReceiveAppointmentUpdate", $"Lịch hẹn {appointmentId} đã bị từ chối.");

            await _emailHelper.EmailForRejectAppointment(appointment, schedule, _context);

            TempData["Message"] = "📛 Đã từ chối lịch hẹn.";
            return RedirectToPage();
        }

        public bool CheckScheduleConflict(int? doctorId, DateTime? appointmentDate, int? shift)
        {
            if (!doctorId.HasValue || !appointmentDate.HasValue || !shift.HasValue)
                return false;

            var existingAppointment = AppointmentsList.Any(a =>
                a.DoctorId == doctorId.Value &&
                a.AppointmentDate.HasValue &&
                a.AppointmentDate.Value.Date == appointmentDate.Value.Date &&
                a.Shift == shift.Value &&
                a.Status == "Đặt lịch thành công");

            // Check if there's a schedule entry that's not available
            var workDate = DateOnly.FromDateTime(appointmentDate.Value);
            var scheduleConflict = SchedulesWithDoctorName.Any(s =>
                s.Schedule.DoctorId == doctorId.Value &&
                s.Schedule.WorkDate == workDate &&
                s.Schedule.Shift == shift.Value
                );

            return existingAppointment || scheduleConflict;
        }

        private async Task UpdateScheduleStatusAsync()
        {
            var currentTime = DateTime.Now;
            var schedulesToUpdate = new List<DoctorSchedule>();

            foreach (var scheduleItem in SchedulesWithDoctorName)
            {
                var schedule = scheduleItem.Schedule;
                if (schedule.WorkDate.HasValue && schedule.Shift.HasValue)
                {
                    var scheduleDateTime = GetScheduleDateTime(schedule.WorkDate.Value, schedule.Shift.Value);

                    if (scheduleDateTime < currentTime)
                    {
                        schedulesToUpdate.Add(schedule);
                    }
                }
            }

            if (schedulesToUpdate.Any())
            {
                foreach (var schedule in schedulesToUpdate)
                {
                    _context.DoctorSchedules.Update(schedule);
                }
                await _context.SaveChangesAsync();
            }
        }

        public DateTime GetScheduleDateTime(DateOnly workDate, int shift)
        {
            var date = workDate.ToDateTime(TimeOnly.MinValue);

            return shift switch
            {
                1 => date.AddHours(8).AddMinutes(30), // Ca 1 ends at 8:30
                2 => date.AddHours(10), // Ca 2 ends at 10:00
                3 => date.AddHours(11).AddMinutes(30), // Ca 3 ends at 11:30
                4 => date.AddHours(15), // Ca 4 ends at 15:00 (3 PM)
                5 => date.AddHours(16).AddMinutes(30), // Ca 5 ends at 16:30 (4:30 PM)
                _ => date.AddHours(23).AddMinutes(59) // Default to end of day
            };
        }
     
        public DateTime GetShiftEndTime(DateOnly workDate, int shift)
        {
            var date = workDate.ToDateTime(TimeOnly.MinValue);

            return shift switch
            {
                1 => date.AddHours(8).AddMinutes(30),
                2 => date.AddHours(10),
                3 => date.AddHours(11).AddMinutes(30),
                4 => date.AddHours(15),
                5 => date.AddHours(16).AddMinutes(30),
                _ => date.AddHours(23).AddMinutes(59)
            };
        }

    }
}
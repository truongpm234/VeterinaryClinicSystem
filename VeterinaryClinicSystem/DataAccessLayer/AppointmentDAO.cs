using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAccessLayer
{
    public class AppointmentDAO
    {
        public static async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            using var _context = new VeterinaryClinicSystemContext();
            var result = await _context.Appointments
                .Include(a => a.Owner)
                .Include(a => a.Pet)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.DoctorNavigation)
                .Include(a => a.Service)
                .ToListAsync();
            return result;
        }

        public static async Task<List<(DoctorSchedule, string)>> GetDoctorSchedulesWithNamesAsync()
        {
            using var _context = new VeterinaryClinicSystemContext();
            var list = await _context.DoctorSchedules
                .Include(s => s.Doctor)
                    .ThenInclude(d => d.DoctorNavigation)
                .Select(s => new ValueTuple<DoctorSchedule, string>(s, s.Doctor!.DoctorNavigation.FullName))
                .ToListAsync();

            return list;
        }

        public static async Task<bool> AcceptAppointmentAsync(int appointmentId)
        {
            using var _context = new VeterinaryClinicSystemContext();
            var appt = await _context.Appointments.FindAsync(appointmentId);
            if (appt == null) return false;

            // Kiểm tra nếu đã có Appointment thành công cho cùng bác sĩ, ngày, ca
            var existing = await _context.Appointments.AnyAsync(a =>
                a.DoctorId == appt.DoctorId &&
                a.AppointmentDate!.Value.Date == appt.AppointmentDate.Value.Date &&
                a.Shift == appt.Shift &&
                a.Status == "Đặt lịch thành công");

            if (existing) return false;

            var workDate = DateOnly.FromDateTime(appt.AppointmentDate.Value);

            // ⚠️ Kiểm tra trùng lịch làm trong DoctorSchedule
            var hasScheduleConflict = await _context.DoctorSchedules.AnyAsync(s =>
                s.DoctorId == appt.DoctorId &&
                s.WorkDate == workDate &&
                s.Shift == appt.Shift);

            if (hasScheduleConflict)
            {
                return false; // Trả về false nếu đã có lịch
            }

            // ✅ Cập nhật trạng thái và thêm lịch làm
            appt.Status = "Đặt lịch thành công";
            var note = $"Ca {appt.Shift}";

            var newSchedule = new DoctorSchedule
            {
                DoctorId = appt.DoctorId,
                WorkDate = workDate,
                Note = note,
                Shift = appt.Shift
            };
            _context.DoctorSchedules.Add(newSchedule);

            await _context.SaveChangesAsync();
            return true;
        }

        public static async Task RejectAppointmentAsync(int appointmentId)
        {
            using var _context = new VeterinaryClinicSystemContext();
            var appt = await _context.Appointments.FindAsync(appointmentId);
            if (appt == null) return;

            appt.Status = "Từ chối hẹn";

            var schedule = await _context.DoctorSchedules.FirstOrDefaultAsync(s => s.DoctorId == appt.DoctorId
                && s.WorkDate == DateOnly.FromDateTime(appt.AppointmentDate.Value)
                && s.Note == ($"Ca {appt.Shift}"));


            await _context.SaveChangesAsync();
        }

        public static async Task<Appointment> AddAsync(Appointment appt)
        {
            using var _context = new VeterinaryClinicSystemContext();

            var entity = (await _context.Appointments.AddAsync(appt)).Entity;
            await _context.SaveChangesAsync();
            return entity;
        }
        public static async Task<bool> UpdateStatusAsync(int appointmentId, string status)
        {
            using var _context = new VeterinaryClinicSystemContext();

            var appt = await _context.Appointments.FindAsync(appointmentId);
            if (appt == null) return false;
            appt.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }
        public static Task<User> GetUserByIdAsync(int userId)
        {
            using var _context = new VeterinaryClinicSystemContext();

            return _context.Users.FindAsync(userId).AsTask();
        }

        public static Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            using var _context = new VeterinaryClinicSystemContext();
            return _context.Doctors.FindAsync(doctorId).AsTask();
        }

        public static Task<List<Service>> GetAllServicesAsync()
        {
            using var _context = new VeterinaryClinicSystemContext();
            return _context.Services
                       .OrderBy(s => s.Name)
                       .ToListAsync();
        }

        public static Task<List<Pet>> GetPetsByOwnerAsync(int ownerId)
        {
            using var _context = new VeterinaryClinicSystemContext();
            return _context.Pets
                       .Where(p => p.OwnerId == ownerId)
                       .ToListAsync();
        }

        public static async Task<List<SelectListItem>> GetDoctorSelectListAsync()
        {
            using var _context = new VeterinaryClinicSystemContext();
            return await _context.Users
                .Where(u => u.RoleId == 3 && u.IsActive)
                .Select(u => new SelectListItem
                {
                    Value = u.UserId.ToString(),
                    Text = u.FullName
                }).ToListAsync();
        }
        public static async Task<List<SelectListItem>> GetServiceSelectListAsync()
        {
            using var _context = new VeterinaryClinicSystemContext();
            return await _context.Services
                .Select(s => new SelectListItem
                {
                    Value = s.ServiceId.ToString(),
                    Text = s.Name
                }).ToListAsync();
        }

        public static async Task<List<SelectListItem>> GetPetSelectListByOwnerAsync(int ownerId)
        {
            using var _context = new VeterinaryClinicSystemContext();
            return await _context.Pets
                .Where(p => p.OwnerId == ownerId)
                .Select(p => new SelectListItem
                {
                    Value = p.PetId.ToString(),
                    Text = p.Name
                }).ToListAsync();
        }
        public static async Task<Appointment?> GetAppointmentByIdAsync(int appointmentId)
        {
            using var _context = new VeterinaryClinicSystemContext();
            return await _context.Appointments
                .Include(a => a.Owner)
                .Include(a => a.Pet)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.DoctorNavigation)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);
        }

        public static async Task<DoctorSchedule?> GetScheduleByDoctorDateShiftAsync(int doctorId, DateOnly date, int shift)
        {
            using var _context = new VeterinaryClinicSystemContext();
            return await _context.DoctorSchedules
                .FirstOrDefaultAsync(s =>
                    s.DoctorId == doctorId &&
                    s.WorkDate.HasValue &&
                    s.WorkDate.Value == date &&
                    s.Shift == shift);
        }
        public static async Task<List<Appointment>> GetAppointmentsByUserAsync(int userId)
        {
            using var _context = new VeterinaryClinicSystemContext();
            return await _context.Appointments
                .Include(a => a.Pet)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.DoctorNavigation)
                .Include(a => a.Service)
                .Where(a => a.OwnerId == userId)
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();
        }

    }
}
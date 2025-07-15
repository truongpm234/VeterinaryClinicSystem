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
        public static Task<List<Appointment>> GetAllAsync()
        {
            using var _context = new VeterinaryClinicSystemContext();

            return _context.Appointments
                .Include(a => a.Owner)
                .Include(a => a.Pet)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.DoctorNavigation)
                .Include(a => a.Service)
                .ToListAsync();
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
                       .OrderBy(s => s.Name)   // ví dụ sort theo tên
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
    }
}
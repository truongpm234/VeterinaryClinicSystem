using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AppointmentDAO
    {
        private readonly VeterinaryClinicSystemContext _context;
        public AppointmentDAO(VeterinaryClinicSystemContext context)
            => _context = context;

        public Task<List<Appointment>> GetAllAsync()
        {
            return _context.Appointments
                           .Include(a => a.Owner)
                           .Include(a => a.Doctor)
                               .ThenInclude(d => d.DoctorNavigation) 
                           .Include(a => a.Service) 
                           .Include(a => a.Pet)      
                           .ToListAsync();
        }

        public async Task<Appointment> AddAsync(Appointment appt)
        {
            appt.CreatedAt = DateTime.UtcNow;
            var entity = (await _context.Appointments.AddAsync(appt)).Entity;
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<User> GetUserByIdAsync(int userId)
            => _context.Users.FindAsync(userId).AsTask();

        public Task<Doctor> GetDoctorByIdAsync(int doctorId)
            => _context.Doctors.FindAsync(doctorId).AsTask();
        public Task<List<Service>> GetAllServicesAsync()
            => _context.Services
                       .OrderBy(s => s.Name)   // ví dụ sort theo tên
                       .ToListAsync();
        public Task<List<Pet>> GetPetsByOwnerAsync(int ownerId)
            => _context.Pets
                       .Where(p => p.OwnerId == ownerId)
                       .ToListAsync();
    }
}

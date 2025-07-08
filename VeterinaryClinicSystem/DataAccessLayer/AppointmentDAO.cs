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

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                                 .Include(a => a.Owner)
                                 .Include(a => a.Doctor)
                                 .ToListAsync();
        }

        public async Task<Appointment> AddAsync(Appointment appt)
        {
            var entity = (await _context.Appointments.AddAsync(appt)).Entity;
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<User> GetUserByIdAsync(int userId)
            => _context.Users.FindAsync(userId).AsTask();

        public Task<Doctor> GetDoctorByIdAsync(int doctorId)
            => _context.Doctors.FindAsync(doctorId).AsTask();
    }
}

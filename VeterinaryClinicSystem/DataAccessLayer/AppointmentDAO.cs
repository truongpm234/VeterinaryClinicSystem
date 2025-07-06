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
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                                 .Include(a => a.Owner)
                                 .Include(a => a.Doctor)
                                 .ToListAsync();
        }

        public async Task<Appointment> AddAsync(Appointment appt)
        {
            var e = (await _context.Appointments.AddAsync(appt)).Entity;
            await _context.SaveChangesAsync();
            return e;
        }

        public async Task<User> GetOwnerByIdAsync(int ownerId)
        {
            return await _context.Users.FindAsync(ownerId);
        }

        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            return await _context.Doctors.FindAsync(doctorId);
        }
    }
}

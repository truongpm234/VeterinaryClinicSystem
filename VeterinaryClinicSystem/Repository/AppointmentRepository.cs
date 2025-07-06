using BusinessObject;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;
using VeterinaryClinicSystem.Repositories;


namespace Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly VeterinaryClinicSystemContext _ctx;
        public AppointmentRepository(VeterinaryClinicSystemContext ctx) => _ctx = ctx;

        public async Task<Appointment> AddAsync(Appointment appt)
        {
            _ctx.Appointments.Add(appt);
            await _ctx.SaveChangesAsync();
            return appt;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _ctx.Appointments
                .Include(a => a.Owner)
                .Include(a => a.Pet)
                .Include(a => a.Doctor)
                .ToListAsync();
        }

        public async Task<User> GetOwnerByIdAsync(int ownerId)
        {
            return await _ctx.Users.FindAsync(ownerId);
        }

        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            return await _ctx.Doctors
                .Include(d => d.DoctorNavigation)
                .FirstOrDefaultAsync(d => d.DoctorId == doctorId);
        }
    }
}

using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;

namespace VeterinaryClinicSystem.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment> AddAsync(Appointment appt);
        Task<List<Appointment>> GetAllAsync();
        Task<User> GetOwnerByIdAsync(int ownerId); 
        Task<Doctor> GetDoctorByIdAsync(int doctorId);
    }
}

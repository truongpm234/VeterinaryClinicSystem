    using BusinessObject;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Threading.Tasks;

namespace Repository
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment> AddAsync(Appointment appt);
        Task<bool> UpdateStatusAsync(int appointmentId, string status);
        Task<User> GetUserByIdAsync(int userId);
        Task<Doctor> GetDoctorByIdAsync(int doctorId);
        Task<List<Service>> GetAllServicesAsync();
        Task<List<Pet>> GetPetsByOwnerAsync(int ownerId);
    }
}

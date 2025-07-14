using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;

namespace VeterinaryClinicSystem.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment> CreateAsync(Appointment appt);

       Task<bool> AcceptAsync(int appointmentId);
      Task<bool> AcceptAsync(int appointmentId, string newStatus);
        Task<List<BusinessObject.Service>> GetAllServicesAsync();
        Task<List<Pet>> GetPetsByOwnerAsync(int ownerId);
    }
}

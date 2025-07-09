using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinicSystem.Repositories;

namespace VeterinaryClinicSystem.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment> CreateAsync(Appointment appt);
        Task<List<BusinessObject.Service>> GetAllServicesAsync();
        Task<List<Pet>> GetPetsByOwnerAsync(int ownerId);
    }
}

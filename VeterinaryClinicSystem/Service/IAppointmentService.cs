using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAppointmentService
    {
        public Task<List<Appointment>> GetAllAppointmentsAsync();
        public Task<List<(DoctorSchedule, string)>> GetDoctorSchedulesWithNamesAsync();
        public Task<bool> AcceptAppointmentAsync(int appointmentId);
        public Task RejectAppointmentAsync(int appointmentId);
        public Task<Appointment> AddAsync(Appointment appt);
        Task<bool> AcceptAsync(int appointmentId);
        Task<bool> AcceptAsync(int appointmentId, string newStatus);
        Task<List<BusinessObject.Service>> GetAllServicesAsync();
        Task<List<Pet>> GetPetsByOwnerAsync(int ownerId);
        Task<List<SelectListItem>> GetDoctorSelectListAsync();
        Task<List<SelectListItem>> GetServiceSelectListAsync();
        Task<List<SelectListItem>> GetPetSelectListByOwnerAsync(int ownerId);
    }
}

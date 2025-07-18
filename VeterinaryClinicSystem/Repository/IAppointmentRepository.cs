using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public Task<List<Appointment>> GetAllAppointmentsAsync();
        public Task<List<(DoctorSchedule, string)>> GetDoctorSchedulesWithNamesAsync();
        public Task<bool> AcceptAppointmentAsync(int appointmentId);
        public Task RejectAppointmentAsync(int appointmentId);
        Task<Appointment> AddAsync(Appointment appt);
        Task<bool> UpdateStatusAsync(int appointmentId, string status);
        Task<User> GetUserByIdAsync(int userId);
        Task<Doctor> GetDoctorByIdAsync(int doctorId);
        Task<List<Service>> GetAllServicesAsync();
        Task<List<Pet>> GetPetsByOwnerAsync(int ownerId);
        Task<List<SelectListItem>> GetDoctorSelectListAsync();
        Task<List<SelectListItem>> GetServiceSelectListAsync();
        Task<List<SelectListItem>> GetPetSelectListByOwnerAsync(int ownerId);
        public Task<Appointment> GetAppointmentByIdAsync(int appointmentId);
        public Task<DoctorSchedule?> GetScheduleByDoctorDateShiftAsync(int doctorId, DateOnly date, int shift);
        public Task<List<Appointment>> GetAppointmentsByUserAsync(int userId);

    }
}

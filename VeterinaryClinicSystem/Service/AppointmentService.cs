using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;
        public AppointmentService(IAppointmentRepository repo)
        { 
            _repo = repo; 
        }
        public Task<List<Appointment>> GetAllAppointmentsAsync() => _repo.GetAllAppointmentsAsync();
        public Task<List<(DoctorSchedule, string)>> GetDoctorSchedulesWithNamesAsync() => _repo.GetDoctorSchedulesWithNamesAsync();
        public Task<bool> AcceptAppointmentAsync(int appointmentId) => _repo.AcceptAppointmentAsync(appointmentId);
        public async Task RejectAppointmentAsync(int appointmentId) => _repo.RejectAppointmentAsync(appointmentId); 
        public Task<Appointment> AddAsync(Appointment appt) => _repo.AddAsync(appt);
        public Task<bool> AcceptAsync(int appointmentId) => _repo.UpdateStatusAsync(appointmentId, "Xác nhận đặt lịch");
        public Task<bool> AcceptAsync(int appointmentId, string newStatus) => _repo.UpdateStatusAsync(appointmentId, newStatus);
        public Task<List<BusinessObject.Service>> GetAllServicesAsync() => _repo.GetAllServicesAsync();
        public Task<List<Pet>> GetPetsByOwnerAsync(int ownerId) => _repo.GetPetsByOwnerAsync(ownerId);
        public Task<List<SelectListItem>> GetDoctorSelectListAsync() => _repo.GetDoctorSelectListAsync();
        public Task<List<SelectListItem>> GetServiceSelectListAsync() => _repo.GetServiceSelectListAsync();
        public Task<List<SelectListItem>> GetPetSelectListByOwnerAsync(int ownerId) => _repo.GetPetSelectListByOwnerAsync(ownerId);
        public Task<Appointment> GetAppointmentByIdAsync(int appointmentId) => _repo.GetAppointmentByIdAsync(appointmentId);
        public Task<DoctorSchedule?> GetScheduleByDoctorDateShiftAsync(int doctorId, DateOnly date, int shift) => _repo.GetScheduleByDoctorDateShiftAsync(doctorId, date, shift);

    }
}
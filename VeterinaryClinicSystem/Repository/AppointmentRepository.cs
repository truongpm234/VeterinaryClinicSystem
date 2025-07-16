using BusinessObject;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public Task<List<Appointment>> GetAllAppointmentsAsync() => AppointmentDAO.GetAllAppointmentsAsync();
        public Task<List<(DoctorSchedule, string)>> GetDoctorSchedulesWithNamesAsync() => AppointmentDAO.GetDoctorSchedulesWithNamesAsync();
        public Task<bool> AcceptAppointmentAsync(int appointmentId) => AppointmentDAO.AcceptAppointmentAsync(appointmentId);
        public Task RejectAppointmentAsync(int appointmentId) => AppointmentDAO.RejectAppointmentAsync(appointmentId);
        public Task<Appointment> AddAsync(Appointment appt) => AppointmentDAO.AddAsync(appt);
        public Task<bool> UpdateStatusAsync(int appointmentId, string status) => AppointmentDAO.UpdateStatusAsync(appointmentId, status);
        public Task<User> GetUserByIdAsync(int userId) => AppointmentDAO.GetUserByIdAsync(userId);
        public Task<Doctor> GetDoctorByIdAsync(int doctorId) => AppointmentDAO.GetDoctorByIdAsync(doctorId);
        public Task<List<Service>> GetAllServicesAsync() => AppointmentDAO.GetAllServicesAsync();
        public Task<List<Pet>> GetPetsByOwnerAsync(int ownerId) => AppointmentDAO.GetPetsByOwnerAsync(ownerId);
        public Task<List<SelectListItem>> GetDoctorSelectListAsync() => AppointmentDAO.GetDoctorSelectListAsync();
        public Task<List<SelectListItem>> GetServiceSelectListAsync() => AppointmentDAO.GetServiceSelectListAsync();
        public Task<List<SelectListItem>> GetPetSelectListByOwnerAsync(int ownerId) => AppointmentDAO.GetPetSelectListByOwnerAsync(ownerId);
        public Task<Appointment> GetAppointmentByIdAsync(int appointmentId) => AppointmentDAO.GetAppointmentByIdAsync(appointmentId);
        public Task<DoctorSchedule?> GetScheduleByDoctorDateShiftAsync(int doctorId, DateOnly date, int shift) => AppointmentDAO.GetScheduleByDoctorDateShiftAsync(doctorId, date, shift);    



    }
}

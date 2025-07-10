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
using Repositories;


namespace Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentDAO _dao;
        public AppointmentRepository(AppointmentDAO dao)
            => _dao = dao;

        public Task<List<Appointment>> GetAllAsync()
            => _dao.GetAllAsync();

        public Task<Appointment> AddAsync(Appointment appt)
            => _dao.AddAsync(appt);

        public Task<User> GetUserByIdAsync(int userId)
            => _dao.GetUserByIdAsync(userId);

        public Task<Doctor> GetDoctorByIdAsync(int doctorId)
            => _dao.GetDoctorByIdAsync(doctorId);
        public Task<List<Service>> GetAllServicesAsync()
            => _dao.GetAllServicesAsync();

        public Task<List<Pet>> GetPetsByOwnerAsync(int ownerId)
            => _dao.GetPetsByOwnerAsync(ownerId);
    }
}

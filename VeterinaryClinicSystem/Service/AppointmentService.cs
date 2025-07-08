using BusinessObject;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinicSystem.Repositories;

namespace Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;
        public AppointmentService(IAppointmentRepository repo)
            => _repo = repo;

        public Task<List<Appointment>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<Appointment> CreateAsync(Appointment appt)
            => _repo.AddAsync(appt);
    }
}
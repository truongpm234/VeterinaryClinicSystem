using BusinessObject;
using DataAccessLayer;
using Repository;
using System.Collections.Generic;

namespace Service
{
    public class DoctorsService : IDoctorsService
    {
        private readonly IDoctorsRepository _iDoctorsRepository;

        // Constructor: Inject the repository
        public DoctorsService(IDoctorsRepository doctorsRepository)
        {
            _iDoctorsRepository = doctorsRepository;
        }

        public List<(User user, Doctor doctor)> GetAllDoctors() => _iDoctorsRepository.GetAllDoctors();
        public (User user, Doctor doctor) GetDoctorByUserId(int id) => _iDoctorsRepository.GetDoctorByUserId(id);
        public void UpdateDoctor(Doctor doctor, string fullName) => _iDoctorsRepository.UpdateDoctor(doctor, fullName);

    }
}

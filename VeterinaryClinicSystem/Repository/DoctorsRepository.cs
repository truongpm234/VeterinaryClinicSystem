using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DoctorsRepository : IDoctorsRepository
    {
        public List<(User user, Doctor doctor)> GetAllDoctors() => DoctorsDAO.GetAllDoctors();
        public (User user, Doctor doctor) GetDoctorByUserId(int id) => ((User user, Doctor doctor))DoctorsDAO.GetDoctorByUserId(id);
        public void UpdateDoctor(Doctor doctor, string fullName) => DoctorsDAO.UpdateDoctor(doctor, fullName);


    }
}

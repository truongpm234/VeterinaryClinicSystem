using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDoctorsRepository
    {
        List<(User user, Doctor doctor)> GetAllDoctors();
        (User user, Doctor doctor) GetDoctorByUserId(int id);
        void UpdateDoctor(Doctor doctor, string fullName);

    }
}

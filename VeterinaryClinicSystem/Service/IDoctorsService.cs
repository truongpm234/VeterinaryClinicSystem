using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDoctorsService
    {
        List<(User user, Doctor doctor)> GetAllDoctors();
        (User user, Doctor doctor) GetDoctorByUserId(int id);
        void UpdateDoctor(Doctor doctor, string fullName);
    }
}

using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DoctorsDAO
    {
        public static List<(User user, Doctor doctor)> GetAllDoctors()
        {
            using var context = new VeterinaryClinicSystemContext();
            var query = from d in context.Doctors
                        join u in context.Users on d.DoctorId equals u.UserId
                        where u.RoleId == 3
                        select new { user = u, doctor = d };

            return query
                .AsEnumerable()
                .Select(x => (x.user, x.doctor))
                .ToList();
        }
        public static (User user, Doctor doctor)? GetDoctorByUserId(int userId)
        {
            using var context = new VeterinaryClinicSystemContext();

            var result = context.Doctors
                .Where(d => d.DoctorId == userId)
                .Join(context.Users,
                      d => d.DoctorId,
                      u => u.UserId,
                      (d, u) => new { User = u, Doctor = d })
                .FirstOrDefault();

            if (result != null)
                return (result.User, result.Doctor);

            return null;
        }

        public static void UpdateDoctor(Doctor doctor, string fullName)
        {
            using var context = new VeterinaryClinicSystemContext();

            var existingDoctor = context.Doctors.FirstOrDefault(d => d.DoctorId == doctor.DoctorId);

            if (existingDoctor != null)
            {
                // Cập nhật bảng Doctor
                existingDoctor.Specialty = doctor.Specialty;
                existingDoctor.Degree = doctor.Degree;
                existingDoctor.Description = doctor.Description;

                var user = context.Users.FirstOrDefault(u => u.UserId == existingDoctor.DoctorId);
                if (user != null)
                {
                    user.FullName = fullName;
                }

                context.SaveChanges();
            }
        }

    }
}

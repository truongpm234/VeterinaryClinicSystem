using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Authentication
    {
        public static User GetUserById(int id)
        {
            using var _context = new VeterinaryClinicSystemContext();

            return _context.Users.FirstOrDefault(e => e.UserId.Equals(id));
        }

        public static User GetUserByEmail(string email)
        {
            using var _context = new VeterinaryClinicSystemContext();

            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email);

        }

        public static void CreateUser(User user)
        {
            using var _context = new VeterinaryClinicSystemContext();

            user.CreatedAt = DateTime.Now;

            if (user.RoleId == null)
                user.RoleId = 5;
            if (user.IsActive == false)
                user.IsActive = true;
            if (user.IsActive == null)
                user.IsActive = true;

            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public static bool IsEmailExists(string email)
        {
            using var _context = new VeterinaryClinicSystemContext();

            return _context.Users.Any(u => u.Email == email);
        }
    }
}

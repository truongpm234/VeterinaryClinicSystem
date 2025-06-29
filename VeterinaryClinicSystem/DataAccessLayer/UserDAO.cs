using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class UserDAO
    {
        public static List<User> GetAllUsers()
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Users.Include(u => u.Role).ToList();
        }

        public static User GetUserById(int id)
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Users.Include(u => u.Role).Include(u => u.Doctor).FirstOrDefault(u => u.UserId == id);
        }

        public static User GetUserByEmail(string email)
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email);
        }

        public static void CreateUser(User user)
        {
            using var context = new VeterinaryClinicSystemContext();
            user.CreatedAt = DateTime.Now;
            user.RoleId ??= 5; 
            context.Users.Add(user);
            context.SaveChanges();
        }

        public static void UpdateUser(User updatedUser)
        {
            using var context = new VeterinaryClinicSystemContext();
            var existingUser = context.Users.Include(u => u.Role).Include(u => u.Doctor).FirstOrDefault(u => u.UserId == updatedUser.UserId);

            if (existingUser != null)
            {
                existingUser.FullName = updatedUser.FullName;
                existingUser.Email = updatedUser.Email;
                existingUser.PhoneNumber = updatedUser.PhoneNumber;
                existingUser.Address = updatedUser.Address;
                existingUser.AvatarUrl = updatedUser.AvatarUrl;

                if (existingUser.RoleId == 3)
                {
                    if (existingUser.Doctor == null)
                    {                       
                        existingUser.Doctor.Specialty = updatedUser.Doctor?.Specialty;
                        existingUser.Doctor.Degree = updatedUser.Doctor?.Degree;
                        existingUser.Doctor.Description = updatedUser.Doctor?.Description;
                    }
                }

                context.SaveChanges();
            }
            if (existingUser == null)
            {
                throw new Exception("User not found.");
            }

        }

        public static void DeleteUser(int userId)
        {
            using var context = new VeterinaryClinicSystemContext();
            var user = context.Users.Find(userId);
            if (user != null)
            {
                user.IsActive = false;
                context.SaveChanges();
            }
        }

        public static void ActiveUser(int activeUser)
        {
            using var context = new VeterinaryClinicSystemContext();
            var user = context.Users.Find(activeUser);
            if (user != null)
            {
                user.IsActive = true;
                context.SaveChanges();
            }
        }
        public static bool IsEmailExists(string email)
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Users.Any(u => u.Email == email);
        }
    }
}

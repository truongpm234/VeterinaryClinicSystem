using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class FeedbackDAO
    {
        public static List<Feedback> GetAll()
        {
            using var _context = new VeterinaryClinicSystemContext();
            return _context.Feedbacks
                    .Include(f => f.Customer)
                    .Include(f => f.Doctor).ThenInclude(d => d.DoctorNavigation)
                    .Include(f => f.Appointment)
                    .OrderByDescending(f => f.CreatedAt)
                    .ToList();
        }
        public static Feedback? GetById(int id)
        {
            using var _context = new VeterinaryClinicSystemContext();
            return _context.Feedbacks
                    .Include(f => f.Customer)
                    .Include(f => f.Doctor)
                    .Include(f => f.Appointment)
                    .FirstOrDefault(f => f.FeedbackId == id);
        }

        public static void Add(Feedback feedback)
        {
            using var _context = new VeterinaryClinicSystemContext();
            //feedback.CreatedAt = DateTime.Now;
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }


        public static void Update(Feedback feedback)
        {
            using var _context = new VeterinaryClinicSystemContext();
            var existing = _context.Feedbacks.Find(feedback.FeedbackId);
            if (existing != null)
            {
                existing.Rating = feedback.Rating;
                existing.Comment = feedback.Comment;
                existing.AppointmentId = feedback.AppointmentId;
                existing.CustomerId = feedback.CustomerId;
                existing.DoctorId = feedback.DoctorId;
                _context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using var _context = new VeterinaryClinicSystemContext();
            var feedback = _context.Feedbacks.Find(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                _context.SaveChanges();
            }
        }
        public static List<User> GetDoctors()
        {
            using var _context = new VeterinaryClinicSystemContext();
            return _context.Users.Where(u => u.RoleId == 3).ToList();
        }
        public static void Save()
        {
            using var _context = new VeterinaryClinicSystemContext();
            _context.SaveChanges();
        }
    }
}
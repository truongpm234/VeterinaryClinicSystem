using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class FeedbackDAO
    {
        private readonly VeterinaryClinicSystemContext _context;

        public FeedbackDAO(VeterinaryClinicSystemContext context)
        {
            _context = context;
        }

        public List<Feedback> GetAll() =>
            _context.Feedbacks
                    .Include(f => f.Customer)
                    .Include(f => f.Doctor).ThenInclude(d => d.DoctorNavigation)
                    .Include(f => f.Appointment)
                    .OrderByDescending(f => f.CreatedAt)
                    .ToList();

        public Feedback? GetById(int id) =>
            _context.Feedbacks
                    .Include(f => f.Customer)
                    .Include(f => f.Doctor)
                    .Include(f => f.Appointment)
                    .FirstOrDefault(f => f.FeedbackId == id);

        public void Add(Feedback feedback)
        {
            //feedback.CreatedAt = DateTime.Now;
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }


        public void Update(Feedback feedback)
        {
            var existing = _context.Feedbacks.Find(feedback.FeedbackId);
            if (existing != null)
            {
                existing.Rating = feedback.Rating;
                existing.Comment = feedback.Comment;
                existing.AppointmentId = feedback.AppointmentId;
                existing.CustomerId = feedback.CustomerId;
                existing.DoctorId = feedback.DoctorId;
                // Don't update CreatedAt
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var feedback = _context.Feedbacks.Find(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

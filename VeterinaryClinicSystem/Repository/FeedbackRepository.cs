using BusinessObject;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public List<Feedback> GetAll() => FeedbackDAO.GetAll();
        public Feedback? GetById(int id) => FeedbackDAO.GetById(id);
        public void Add(Feedback feedback) => FeedbackDAO.Add(feedback);
        public void Update(Feedback feedback) => FeedbackDAO.Update(feedback);
        public void Save() => FeedbackDAO.Save();
        public void Delete(int id) => FeedbackDAO.Delete(id);
        public List<User> GetDoctors() => FeedbackDAO.GetDoctors();
    }
}
using BusinessObject;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackDAO _dao;

        public FeedbackRepository(FeedbackDAO dao)
        {
            _dao = dao;
        }

        public List<Feedback> GetAll() => _dao.GetAll();
        public Feedback? GetById(int id) => _dao.GetById(id);
        public void Add(Feedback feedback) => _dao.Add(feedback);
        public void Update(Feedback feedback) => _dao.Update(feedback);

        public void Save() => _dao.Save();

        public void Delete(int id) => _dao.Delete(id);
    }
}

using BusinessObject;

namespace Repository
{
    public interface IFeedbackRepository
    {
        List<Feedback> GetAll();
        Feedback? GetById(int id);
        void Add(Feedback feedback);
        void Update(Feedback feedback);
        void Delete(int id);
        void Save();
    }
}

using BusinessObject;

namespace Service
{
    public interface IFeedbackService
    {
        List<Feedback> GetAll();
        Feedback? GetById(int id);
        void Add(Feedback feedback);
        void Update(Feedback feedback);
        void Delete(int id);
        
        List<User> GetDoctors();
    }
}

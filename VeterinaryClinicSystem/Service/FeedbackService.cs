using BusinessObject;
using DataAccessLayer;
using Repository;

namespace Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackService(IFeedbackRepository repository, VeterinaryClinicSystemContext context)
        {
            _repository = repository;
        }

        public List<Feedback> GetAll() => _repository.GetAll();
        public Feedback? GetById(int id) => _repository.GetById(id);
        public void Add(Feedback feedback) => _repository.Add(feedback);
        public void Update(Feedback feedback) => _repository.Update(feedback);
        public void Delete(int id) => _repository.Delete(id);
        public List<User> GetDoctors() => _repository.GetDoctors();

    }

}
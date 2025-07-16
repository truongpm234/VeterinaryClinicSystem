using BusinessObject;
using DataAccessLayer;
using Repository;

namespace Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repository;
        private readonly VeterinaryClinicSystemContext _context;

        public FeedbackService(IFeedbackRepository repository, VeterinaryClinicSystemContext context)
        {
            _repository = repository;
            _context = context;
        }

        public List<Feedback> GetAll() => _repository.GetAll();
        public Feedback? GetById(int id) => _repository.GetById(id);
        public void Add(Feedback feedback)
        {
            _repository.Add(feedback);

        }
        public void Update(Feedback feedback) => _repository.Update(feedback);
        public void Delete(int id) => _repository.Delete(id);


        public List<User> GetDoctors()
        {
            return _context.Users.Where(u => u.RoleId == 3).ToList();
        }
    }

}

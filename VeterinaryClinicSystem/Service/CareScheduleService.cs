using BusinessObject;
using Repository;
using System.Collections.Generic;

namespace Service
{
    public class CareScheduleService : ICareScheduleService
    {
        private readonly ICareScheduleRepository _careScheduleRepository;


        public CareScheduleService(ICareScheduleRepository repo)
        {
            _careScheduleRepository = repo;
        }

        public List<CareSchedule> GetSchedulesByPetId(int petId) => _careScheduleRepository.GetSchedulesByPetId(petId);

        public Pet? GetPetById(int petId) => _careScheduleRepository.GetPetById(petId);
        public void Add(CareSchedule schedule) => _careScheduleRepository.Add(schedule);

    }
}

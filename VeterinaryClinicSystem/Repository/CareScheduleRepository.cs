using BusinessObject;
using DataAccessLayer;
using System.Collections.Generic;

namespace Repository
{
    public class CareScheduleRepository : ICareScheduleRepository
    {
        public List<CareSchedule> GetSchedulesByPetId(int petId) => CareScheduleDAO.GetSchedulesByPetId(petId);

        public Pet? GetPetById(int petId) => CareScheduleDAO.GetPetById(petId);
        public void Add(CareSchedule schedule) => CareScheduleDAO.Add(schedule);
    }
}

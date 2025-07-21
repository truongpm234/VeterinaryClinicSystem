using BusinessObject;
using System.Collections.Generic;

namespace Repository
{
    public interface ICareScheduleRepository
    {
        List<CareSchedule> GetSchedulesByPetId(int petId);
        Pet? GetPetById(int petId);
        void Add(CareSchedule schedule);
    }
}

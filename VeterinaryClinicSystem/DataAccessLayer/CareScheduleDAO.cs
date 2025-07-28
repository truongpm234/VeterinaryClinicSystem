using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class CareScheduleDAO
    {
        public static List<CareSchedule> GetSchedulesByPetId(int petId)
        {
            using var context = new VeterinaryClinicSystemContext();

            var schedules = (from cs in context.CareSchedules.Include(cs => cs.Pet)
                             join s in context.Services on cs.CareType equals s.Name
                             where cs.PetId == petId
                                   && cs.CareType.Contains("Tiêm phòng")
                             select new CareSchedule
                             {
                                 ScheduleId = cs.ScheduleId,
                                 PetId = cs.PetId,
                                 CareType = cs.CareType,
                                 InitialDate = cs.InitialDate,
                                 NextDueDate = cs.NextDueDate,
                                 IsCompleted = cs.IsCompleted,
                                 Note = $"Dịch vụ: {s.Name} - Giá: {s.Price:N0} VNĐ",
                                 Pet = cs.Pet
                             }).ToList();

            return schedules;
        }


        public static Pet? GetPetById(int petId)
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Pets.FirstOrDefault(p => p.PetId == petId);
        }

        public static void Add(CareSchedule schedule)
        {
            using var context = new VeterinaryClinicSystemContext();
            context.CareSchedules.Add(schedule);
            context.SaveChanges();
        }

    }
}

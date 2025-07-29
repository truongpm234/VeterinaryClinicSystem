using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMedicalRecordsRepository
    {
        List<MedicalRecord> GetAllMedicalRecords();
        List<MedicalRecord> GetMedicalRecordsByPetId(int petId);
        void AddMedicalRecord(MedicalRecord newRecord);
        public List<Pet> GetPetsWithAppointmentsTodayForDoctor(int? doctorId = null);

    }
}

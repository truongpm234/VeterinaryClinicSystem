using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IMedicalRecordsService
    {
        List<MedicalRecord> GetAllMedicalRecords();
        List<MedicalRecord> GetMedicalRecordsByPetId(int petId);
        void AddMedicalRecord(MedicalRecord newRecord);
        public List<Pet> GetPetsWithAppointmentsTodayForDoctor(int? doctorId = null);

    }
}

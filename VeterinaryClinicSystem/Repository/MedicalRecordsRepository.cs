using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MedicalRecordsRepository : IMedicalRecordsRepository
    {
        public void AddMedicalRecord(MedicalRecord newRecord) => MedicalRecordsDAO.AddMedicalRecord(newRecord);

        public List<MedicalRecord> GetAllMedicalRecords() => MedicalRecordsDAO.GetAllMedicalRecords();

        public List<MedicalRecord> GetMedicalRecordsByPetId(int petId) => MedicalRecordsDAO.GetMedicalRecordsByPetId((int)petId);
        public List<Pet> GetPetsWithAppointmentsTodayForDoctor(int? doctorId = null) => MedicalRecordsDAO.GetPetsWithAppointmentsTodayForDoctor(doctorId);

    }
}

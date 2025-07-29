using BusinessObject;
using DataAccessLayer;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MedicalRecordsService : IMedicalRecordsService
    {
        private readonly IMedicalRecordsRepository _medicalRecordsRepository;

        public MedicalRecordsService(IMedicalRecordsRepository medicalRecordsRepository)
        {
            _medicalRecordsRepository = medicalRecordsRepository;
        }

        public void AddMedicalRecord(MedicalRecord newRecord) => _medicalRecordsRepository.AddMedicalRecord(newRecord);

        public List<MedicalRecord> GetAllMedicalRecords() => _medicalRecordsRepository.GetAllMedicalRecords();

        public List<MedicalRecord> GetMedicalRecordsByPetId(int petId) => _medicalRecordsRepository.GetMedicalRecordsByPetId((int)petId);
        public List<Pet> GetPetsWithAppointmentsTodayForDoctor(int? doctorId = null) => _medicalRecordsRepository.GetPetsWithAppointmentsTodayForDoctor(doctorId);

    }
}

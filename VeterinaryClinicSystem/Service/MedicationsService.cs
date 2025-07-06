using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MedicationsService : IMedicationsService
    {

        private readonly IMedicationsRepository _medicationRepository;

        public MedicationsService(IMedicationsRepository medicationsRepository)
        {
            _medicationRepository =  medicationsRepository;
        }

        public List<Medication> GetAllMedications() => _medicationRepository.GetAllMedications();

        public Medication GetMedicationById(int id) => _medicationRepository.GetMedicationById(id);

        public void AddMedication(Medication medication) => _medicationRepository.AddMedication(medication);

        public void UpdateMedication(Medication updated) => _medicationRepository.UpdateMedication(updated);

        public void DeleteMedication(int id) => _medicationRepository?.DeleteMedication(id);
    }
}

using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MedicationsRepository : IMedicationsRepository
    {
        public List<Medication> GetAllMedications() => MedicationDAO.GetAllMedications();

        public Medication GetMedicationById(int id) => MedicationDAO.GetMedicationById(id);

        public void AddMedication(Medication medication) => MedicationDAO.AddMedication(medication);

        public void UpdateMedication(Medication updated) => MedicationDAO.UpdateMedication(updated);

        public void DeleteMedication(int id) => MedicationDAO.DeleteMedication(id);
    }
}

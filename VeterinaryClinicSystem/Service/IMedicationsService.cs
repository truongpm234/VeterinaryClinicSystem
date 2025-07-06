using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IMedicationsService
    {
        List<Medication> GetAllMedications();
        Medication GetMedicationById(int id);
        void AddMedication(Medication medication);
        void UpdateMedication(Medication updated);
        void DeleteMedication(int id);
    }
}

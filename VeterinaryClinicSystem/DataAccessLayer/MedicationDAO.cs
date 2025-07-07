using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MedicationDAO
    {
        public static List<Medication> GetAllMedications()
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Medications.ToList();
        }
        public static Medication GetMedicationById(int id)
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Medications.FirstOrDefault(m => m.MedicationId == id);
        }
        public static void AddMedication(Medication medication)
        {
            using var context = new VeterinaryClinicSystemContext();
            context.Medications.Add(medication);
            context.SaveChanges();
        }
        public static void UpdateMedication(Medication updated)
        {
            using var context = new VeterinaryClinicSystemContext();
            var existing = context.Medications.FirstOrDefault(m => m.MedicationId == updated.MedicationId);

            if (existing != null)
            {
                existing.Name = updated.Name;
                existing.Description = updated.Description;
                existing.Unit = updated.Unit;
                existing.Price = updated.Price;
                existing.Stock = updated.Stock;
                context.SaveChanges();
            }
        }
        public static void DeleteMedication(int id)
        {
            using var context = new VeterinaryClinicSystemContext();
            var medication = context.Medications.FirstOrDefault(m => m.MedicationId == id);
            if (medication != null)
            {
                context.Medications.Remove(medication);
                context.SaveChanges();
            }
        }
    }
}

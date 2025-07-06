using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class InventoryTransactionDAO
    {
        public static List<InventoryTransaction> GetAll()
        {
            using var context = new VeterinaryClinicSystemContext();

            return context.InventoryTransactions
                          .Include(t => t.Medication) 
                          .OrderByDescending(t => t.TransactionDate)
                          .ToList();
        }

        public static void Add(InventoryTransaction transaction)
        {
            using var context = new VeterinaryClinicSystemContext();

            var medication = context.Medications.FirstOrDefault(m => m.MedicationId == transaction.MedicationId);
            if (medication == null) return;

            // Cập nhật tồn kho
            if (transaction.Type == "IN")
            {
                medication.Stock += transaction.Quantity ?? 0;
            }
            else if (transaction.Type == "OUT")
            {
                medication.Stock -= transaction.Quantity ?? 0;
            }

            context.InventoryTransactions.Add(transaction);
            context.SaveChanges();
        }
        public static void Delete(int id)
        {
            using var context = new VeterinaryClinicSystemContext();
            var transaction = context.InventoryTransactions.FirstOrDefault(t => t.TransactionId == id);
            if (transaction != null)
            {
                context.InventoryTransactions.Remove(transaction);
                context.SaveChanges();
            }
        }

    }
}

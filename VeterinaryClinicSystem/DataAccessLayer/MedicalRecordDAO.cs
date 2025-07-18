using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MedicalRecordDAO
    {
        public static BillDetail CalculateTotalBillForAppointment(int appointmentId)
        {
            using var context = new VeterinaryClinicSystemContext();

            var bill = new BillDetail();

            var medicalRecords = context.MedicalRecords
                .Include(m => m.PrescriptionDetails)
                    .ThenInclude(p => p.Medication)
                .Where(m => m.AppointmentId == appointmentId)
                .ToList();

            foreach (var record in medicalRecords)
            {
                foreach (var prescription in record.PrescriptionDetails)
                {
                    var med = prescription.Medication;
                    if (med == null) continue;

                    var unitPrice = med.Price ?? 0;
                    var total = unitPrice * prescription.Amount;

                    bill.Medications.Add((med.Name ?? "Không rõ", unitPrice, prescription.Amount, total));
                    bill.MedicationTotal += total;
                }
            }

            bill.ServicePrice = context.Appointments
                .Include(a => a.Service)
                .Where(a => a.AppointmentId == appointmentId)
                .Select(a => a.Service!.Price ?? 0)
                .FirstOrDefault();

            return bill;
        }

    }
}

using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MedicalRecordsDAO
    {
        public static List<MedicalRecord> GetAllMedicalRecords()
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.MedicalRecords
                .Include(r => r.Pet)
                .Include(r => r.Doctor)
                .Include(r => r.Appointment)
                .ToList();
        }

        public static List<MedicalRecord> GetMedicalRecordsByPetId(int petId)
        {
            using var context = new VeterinaryClinicSystemContext();
            var records = context.MedicalRecords
                .Include(r => r.Doctor)
                .Include(r => r.Appointment)
                .Where(r => r.PetId == petId)
                .ToList();

            return records;
        }
        public static Pet? GetPetById(int petId)
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Pets.FirstOrDefault(p => p.PetId == petId);
        }

        public static void AddMedicalRecord(MedicalRecord newRecord)
        {
            using var context = new VeterinaryClinicSystemContext();

            // TÌM HOẶC LẤY PET
            if (newRecord.Pet == null && newRecord.PetId.HasValue)
            {
                newRecord.Pet = context.Pets.FirstOrDefault(p => p.PetId == newRecord.PetId);
            }

            if (newRecord.Pet == null)
            {
                throw new Exception($"Pet not found (PetId: {newRecord.PetId}).");
            }

            // TÌM HOẶC LẤY DOCTOR
            if (newRecord.Doctor == null && newRecord.DoctorId.HasValue)
            {
                newRecord.Doctor = context.Doctors.FirstOrDefault(d => d.DoctorId == newRecord.DoctorId);
            }

            if (newRecord.Doctor == null)
            {
                throw new Exception($"Doctor not found (DoctorId: {newRecord.DoctorId}).");
            }

            // TÌM HOẶC LẤY APPOINTMENT
            if (newRecord.Appointment == null && newRecord.AppointmentId.HasValue)
            {
                newRecord.Appointment = context.Appointments.FirstOrDefault(a => a.AppointmentId == newRecord.AppointmentId);
            }

            if (newRecord.Appointment == null)
            {
                throw new Exception($"Appointment not found (AppointmentId: {newRecord.AppointmentId}).");
            }

            // Gán Id từ navigation property nếu thiếu
            newRecord.PetId = newRecord.Pet.PetId;
            newRecord.DoctorId = newRecord.Doctor.DoctorId;
            newRecord.AppointmentId = newRecord.Appointment.AppointmentId;

            newRecord.CreatedAt = DateTime.Now;

            context.MedicalRecords.Add(newRecord);
            context.SaveChanges();
        }

        public static List<Pet> GetPetsWithAppointmentsTodayForDoctor(int? doctorId = null)
        {
            using var context = new VeterinaryClinicSystemContext();

            var today = DateTime.Today;

            var query = context.Pets
                .Include(p => p.Owner)
                .Include(p => p.Appointments)
                .Where(p => p.Appointments.Any(a =>
                    a.AppointmentDate.HasValue &&
                    a.AppointmentDate.Value.Date == today &&
                    a.Status == "Đặt lịch thành công"));

            if (doctorId.HasValue)
            {
                query = query.Where(p => p.Appointments.Any(a => a.DoctorId == doctorId.Value));
            }

            return query.ToList();
        }


    }
}

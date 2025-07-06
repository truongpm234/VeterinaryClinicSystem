using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PetDAO
    {
        //  Get All Pets
        public static List<Pet> GetAllPets()
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Pets
                          .Include(p => p.Owner) // Nếu cần lấy Owner luôn
                          .ToList();
        }

        //  Get Pet by ID
        public static Pet? GetPetById(int petId)
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Pets
                          .Include(p => p.Owner)
                          .FirstOrDefault(p => p.PetId == petId);
        }

        //  Add Pet
        public static void AddPet(Pet newPet)
        {
            using var context = new VeterinaryClinicSystemContext();
            newPet.CreatedAt = DateTime.Now;
            context.Pets.Add(newPet);
            context.SaveChanges();
        }

        //  Update Pet
        public static void UpdatePet(Pet updatedPet)
        {
            using var context = new VeterinaryClinicSystemContext();
            var existingPet = context.Pets.FirstOrDefault(p => p.PetId == updatedPet.PetId);

            if (existingPet == null)
            {
                throw new Exception($"Pet with ID {updatedPet.PetId} not found.");
            }

            // Update các field
            existingPet.Name = updatedPet.Name;
            existingPet.Species = updatedPet.Species;
            existingPet.Breed = updatedPet.Breed;
            existingPet.Gender = updatedPet.Gender;
            existingPet.BirthDate = updatedPet.BirthDate;
            existingPet.Weight = updatedPet.Weight;
            existingPet.Note = updatedPet.Note;
            existingPet.OwnerId = updatedPet.OwnerId;

            context.SaveChanges();
        }

        // Xóa Pet
        public static void DeletePet(int petId)
        {
            using var context = new VeterinaryClinicSystemContext();
            var pet = context.Pets.FirstOrDefault(p => p.PetId == petId);

            if (pet == null)
            {
                throw new Exception($"Pet with ID {petId} not found.");
            }

            context.Pets.Remove(pet);
            context.SaveChanges();
        }
    }

}

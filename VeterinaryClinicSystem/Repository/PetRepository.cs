using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PetRepository : IPetRepository
    {
        public void AddPet(Pet newPet) =>PetDAO.AddPet(newPet);

        public void DeletePet(int petId) => PetDAO.DeletePet(petId);

        public List<Pet> GetAllPets() => PetDAO.GetAllPets();

        public Pet? GetPetById(int petId) => PetDAO.GetPetById(petId);
        public void UpdatePet(Pet updatedPet) => PetDAO.UpdatePet(updatedPet);
        public List<Pet> GetPetByCustomerId(int customerId) => PetDAO.GetPetByCustomerId(customerId);
    }
}

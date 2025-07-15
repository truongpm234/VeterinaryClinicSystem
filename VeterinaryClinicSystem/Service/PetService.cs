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
    public class PetService : IPetService
    {
        private readonly IPetRepository repository;

        public PetService(IPetRepository petRepository)
        {
            repository = petRepository;
        }
        public void AddPet(Pet newPet) => repository.AddPet(newPet);

        public void DeletePet(int petId) => repository.DeletePet(petId);

        public List<Pet> GetAllPets() => repository.GetAllPets();

        public Pet? GetPetById(int petId) => repository.GetPetById(petId);
        public void UpdatePet(Pet updatedPet) => repository.UpdatePet(updatedPet);
    }
}

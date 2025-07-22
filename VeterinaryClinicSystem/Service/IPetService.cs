using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPetService
    {
        //  Get All Pets
        List<Pet> GetAllPets();

        //  Get Pet by ID
        Pet? GetPetById(int petId);

        //  Add Pet
        void AddPet(Pet newPet);

        //  Update Pet
        void UpdatePet(Pet updatedPet);

        // Xóa Pet
        void DeletePet(int petId);
        List<Pet> GetPetByCustomerId(int customerId);
    }
}

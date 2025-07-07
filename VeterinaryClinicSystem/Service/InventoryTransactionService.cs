using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class InventoryTransactionService : IInventoryTransactionService
    {
        public readonly IInventoryTransactionRepository _inventoryTransactionRepository;

        public InventoryTransactionService(IInventoryTransactionRepository inventoryTransactionRepository)
        {
            _inventoryTransactionRepository =  inventoryTransactionRepository;
        }
        public void Add(InventoryTransaction transaction) => _inventoryTransactionRepository.Add(transaction);

        public List<InventoryTransaction> GetAll() => _inventoryTransactionRepository.GetAll();
        public void DeleteTransaction(int id) => _inventoryTransactionRepository.DeleteTransaction(id);
    }
}

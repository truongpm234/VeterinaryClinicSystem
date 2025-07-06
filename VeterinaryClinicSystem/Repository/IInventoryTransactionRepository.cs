using BusinessObject;
using System.Collections.Generic;

namespace Repository
{
    public interface IInventoryTransactionRepository
    {
        void Add(InventoryTransaction transaction);
        List<InventoryTransaction> GetAll();
        void DeleteTransaction(int id);

    }
}


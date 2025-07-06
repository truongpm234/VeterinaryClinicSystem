using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IInventoryTransactionService
    {
        void Add(InventoryTransaction transaction);
        List<InventoryTransaction> GetAll();
        void DeleteTransaction(int id);

    }
}

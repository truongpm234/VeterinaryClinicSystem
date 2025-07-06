using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        public void Add(InventoryTransaction transaction) => InventoryTransactionDAO.Add(transaction);

        public List<InventoryTransaction> GetAll() => InventoryTransactionDAO.GetAll();
        public void DeleteTransaction(int id) => InventoryTransactionDAO.Delete(id);


    }
}

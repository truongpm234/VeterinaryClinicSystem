using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PrescriptionDetailRepository : IPrescriptionDetailRepository
    {
        public void AddPrescriptionDetails(List<PrescriptionDetail> items, int recordId) => PrescriptionDetailDAO.AddPrescriptionDetails(items, recordId);

    }
}

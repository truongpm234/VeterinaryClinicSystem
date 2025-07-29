using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PrescriptionDetailService : IPrescriptionDetailService
    {
        private readonly IPrescriptionDetailRepository _prescriptionDetailRepository;
        public PrescriptionDetailService(IPrescriptionDetailRepository prescriptionDetailRepository)
        {
            _prescriptionDetailRepository = prescriptionDetailRepository;
        }
        public void AddPrescriptionDetails(List<PrescriptionDetail> items, int recordId) => _prescriptionDetailRepository.AddPrescriptionDetails(items, recordId);
    }
}

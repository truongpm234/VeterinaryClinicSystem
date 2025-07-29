using BusinessObject;

namespace Service
{
    public interface IPrescriptionDetailService
    {
        public void AddPrescriptionDetails(List<PrescriptionDetail> items, int recordId);

    }
}
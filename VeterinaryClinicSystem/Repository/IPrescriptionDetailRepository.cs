using BusinessObject;

namespace Repository
{
    public interface IPrescriptionDetailRepository
    {
        public void AddPrescriptionDetails(List<PrescriptionDetail> items, int recordId);
    }
}
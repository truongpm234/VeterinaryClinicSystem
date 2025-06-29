using BusinessObject;
using DataAccessLayer;

namespace Repository
{
    public interface IServicesRepository
    {
        List<Service> GetAllServices();
        Service GetServiceById(int id);
        
    }
}
using BusinessObject;
using DataAccessLayer;

namespace Repository
{
    public interface IServicesRepository
    {
        List<Service> GetAllServices();
        Service GetServiceById(int id);
        void AddService(Service service);
        void UpdateService(Service updated);
        void DeleteService(int id);

    }
}
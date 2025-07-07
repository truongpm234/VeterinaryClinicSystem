using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace Service
{
    public interface IServicesService
    {
        List<BusinessObject.Service> GetAllServices();
        BusinessObject.Service GetServiceById(int id);
        void AddService(BusinessObject.Service service);
        void UpdateService(BusinessObject.Service updated);
        void DeleteService(int id);
    }

}

using DataAccessLayer;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Service
{
    public class ServicesService : IServicesService
    {
        public readonly IServicesRepository _serviceRepository;

        public ServicesService(IServicesRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public List<BusinessObject.Service> GetAllServices() => _serviceRepository.GetAllServices();

        public BusinessObject.Service GetServiceById(int id) => _serviceRepository.GetServiceById(id); 
        public void UpdateService(BusinessObject.Service updated) => _serviceRepository.UpdateService(updated);
        public void AddService(BusinessObject.Service service) => _serviceRepository.AddService(service);

        public void DeleteService(int id) => _serviceRepository.DeleteService(id);


    }
}

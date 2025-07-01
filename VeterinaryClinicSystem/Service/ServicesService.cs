using DataAccessLayer;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}

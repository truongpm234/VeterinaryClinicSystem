using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Repository
{
    public class ServicesRepository : IServicesRepository
    {
        public List<Service> GetAllServices() => ServiceDAO.GetAllServices();
        public Service? GetServiceById(int id) => ServiceDAO.GetServiceById(id);
        public void AddService(Service service) => ServiceDAO.AddService(service);
        public void UpdateService(Service updated) => ServiceDAO.UpdateService(updated);
        public void DeleteService(int id) => ServiceDAO.DeleteService(id);
    }
}

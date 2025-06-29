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
            public Service GetServiceById(int id) => ServiceDAO.GetServiceById(id);

    }
}

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
    }

}

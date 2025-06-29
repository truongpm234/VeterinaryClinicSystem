using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ServiceDAO
    {
        public static List<Service> GetAllServices()
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Services.ToList();
        }

        public static Service GetServiceById(int id)
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Services.FirstOrDefault(s => s.ServiceId == id);
        }
    }
}

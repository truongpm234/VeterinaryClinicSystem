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

        public static Service? GetServiceById(int id)
        {
            using var context = new VeterinaryClinicSystemContext();
            return context.Services.FirstOrDefault(s => s.ServiceId == id);
        }

        public static void UpdateService(Service updated)
        {
            using var context = new VeterinaryClinicSystemContext();
            var existing = context.Services.FirstOrDefault(s => s.ServiceId == updated.ServiceId);
            
            if (existing != null)
            {
                existing.Name = updated.Name;
                existing.Description = updated.Description;
                existing.Price = updated.Price;
                existing.ServiceType = updated.ServiceType;
                context.SaveChanges();
            }
        }

        public static void DeleteService(int id)
        {
            using var context = new VeterinaryClinicSystemContext();
            var service = context.Services.FirstOrDefault(s => s.ServiceId == id);
            if (service != null)
            {
                context.Services.Remove(service);
                context.SaveChanges();
            }
        }

        public static void AddService(Service newService)
        {
            using var context = new VeterinaryClinicSystemContext();
            context.Services.Add(newService);
            context.SaveChanges();
        }
        
    }
}
